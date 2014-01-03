using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBDescriptorExtension.Constants;
using OpenBabel;

namespace OBDescriptorExtension
{
    public static class OBMolExtensions
    {
        /// <summary>
        /// Computes the number of fragments in molecule given a SMARTS pattern
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="pattern">SMARTS pattern (string)</param>
        /// <returns></returns>
        public static int SmartPatternCount(this OBMol mol, string pattern)
        {
            var sp = new OBSmartsPattern();
            sp.Init(pattern);
            sp.Match(mol);
            return sp.GetUMapList().Count;
        }

        /// <summary>
        /// Calculates the approximate surface area contributions for each atom
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="includeHydrogens">Include hydrogens in calculation</param>
        /// <returns></returns>
        public static double[] LabuteASAContributions(this OBMol mol, bool includeHydrogens=true)
        {
            var numAtoms = mol.NumAtoms();
            var Vi = new double[numAtoms + 1].Zero().ToArray();
            var rads = new double[numAtoms + 1].Zero().ToArray();
            rads[0] = AtomicConstants.GetRBO(1);
            double Ri, Rj, Bij, Dij;


            // OpenBabel atom numbering is 1-based
            for (var i = 1; i <= numAtoms; i++)
            {
                rads[i] = AtomicConstants.GetRBO(mol.GetAtom(i).GetAtomicNum());
            }

            foreach (var bond in mol.Bonds())
            {
                var beginAtom = bond.GetBeginAtomIdx();
                var endAtom = bond.GetEndAtomIdx();
                Ri = rads[beginAtom];
                Rj = rads[endAtom];
                var bondOrder = bond.GetBondOrder();
                Bij = !bond.IsAromatic() ? Ri + Rj - BondConstants.BondScaleFactors[bondOrder] : Ri + Rj - BondConstants.BondScaleFactors[0];

                Dij = Math.Min(Math.Max(Math.Abs(Ri - Rj), Bij), Ri + Rj);
                Vi[beginAtom] += Rj * Rj - Math.Pow((Ri - Dij), 2) / Dij;
                Vi[endAtom] += Ri * Ri - Math.Pow((Rj - Dij), 2) / Dij;
            }

            if (includeHydrogens)
            {
                Rj = rads[0];
                for (var i = 1; i <= numAtoms; i++)
                {
                    Ri = rads[i];
                    Bij = Ri + Rj;
                    Dij = Math.Min(Math.Max(Math.Abs(Ri - Rj), Bij), Ri + Rj);
                    Vi[i] += Rj * Rj - Math.Pow((Ri - Dij), 2) / Dij;
                    Vi[0] += Ri * Ri - Math.Pow((Rj - Dij), 2) / Dij;
                }
            }
            for (var i = 0; i <= numAtoms; i++)
            {
                Ri = rads[i];
                Vi[i] = 4 * Math.PI * Math.Pow(Ri, 2) - Math.PI * Ri * Vi[i];
            }
            return Vi;
        }

        /// <summary>
        /// Assigns Gasteiger partial charges to molecule
        /// </summary>
        /// <returns>OBMol with Gasteiger partial charges assigned</returns>
        public static OBMol AssignGasteigerCharges(this OBMol mol)
        {
            var newMol = mol.AddExplicitHydrogens();
            newMol.UnsetPartialChargesPerceived();
            foreach (var atom in newMol.Atoms())
            {
                atom.GetPartialCharge();
            }
            return newMol;
        }

        /// <summary>
        /// Performs a mol copy and adds explicit hydrogens to each heavy atom to the copy
        /// </summary>
        /// <param name="mol"></param>
        /// <returns>Copy of original mol with explicit hydrogens</returns>
        public static OBMol AddExplicitHydrogens(this OBMol mol)
        {
            var newMol = new OBMol(mol);
            foreach (var atom in newMol.Atoms())
            {
                newMol.AddHydrogens(atom);
            }
            return newMol;
        }

        

        /// <summary>
        /// Calculates the Crippen SMR VSA contributions from each atom
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] CrippenSmrVsaContributions(this OBMol mol, bool includeHydrogens)
        {
            var newMol = includeHydrogens ? mol.AddExplicitHydrogens() : mol;
            var result = new List<double>();
            foreach(var atom in newMol.Atoms())
            {
                var key = atom.GetCrippenKey();
                if (!string.IsNullOrEmpty(key))
                {
                    result.Add(CrippenConstants.GetMolarRefractivity(key));
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Calculates the Crippen SLogP VSA contributions from each atom
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] CrippenSLogPVsaContributions(this OBMol mol, bool includeHydrogens)
        {
            var newMol = includeHydrogens ? mol.AddExplicitHydrogens() : mol;
            var result = new List<double>();
            foreach (var atom in newMol.Atoms())
            {
                var key = atom.GetCrippenKey();
                if (!string.IsNullOrEmpty(key))
                {
                    result.Add(CrippenConstants.GetLogP(key));
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Chi0 atomic connectivity index (order 0)
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Chi0(this OBMol mol)
        {
            return mol.Atoms().Where(a => a.GetValence() > 0).Select(a => Math.Sqrt(1 / (double) a.GetValence())).Sum();
        }

        /// <summary>
        /// Chi1 atomic connectivity index (order 1)
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Chi1(this OBMol mol)
        {
            return mol.Bonds().Where(b => b.GetBeginAtom().GetValence() * b.GetEndAtom().GetValence() > 0)
                              .Select(b => Math.Sqrt(1 / (double)(b.GetBeginAtom().GetValence() * b.GetEndAtom().GetValence()))).Sum();
        }

        /// <summary>
        /// Chi0v Atomic valence connectivity index (order 0)
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Chi0v(this OBMol mol)
        {
            return mol.HkDeltas().Where(d => d > 0).Select(d => Math.Sqrt(1 / d)).Sum(); 
        }

        /// <summary>
        /// Chi1v atomic valence connectivity index (order 0)
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Chi1v(this OBMol mol)
        {
            var deltas = mol.HkDeltas(false);
            return mol.Bonds().Where(b => deltas[b.GetBeginAtomIdx() - 1] * deltas[b.GetEndAtomIdx() - 1] > 0)
                              .Select(b => Math.Sqrt(1 / (double)(deltas[b.GetBeginAtomIdx() - 1] * deltas[b.GetEndAtomIdx() -1]))).Sum();
        }

        /// <summary>
        /// Chi0n atomic valence number connectivity index (order 0)
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Chi0n(this OBMol mol)
        {
            return mol.Atoms().Where(a => a.ValenceNumber() > 0).Select(a => Math.Sqrt(1 / (double)a.ValenceNumber())).Sum();
        }

        /// <summary>
        /// Chi1n atomic valence number connectivity index (order 1)
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Chi1n(this OBMol mol)
        {
            return mol.Bonds().Where(b => b.GetBeginAtom().ValenceNumber() * b.GetEndAtom().ValenceNumber() > 0)
                              .Select(b => Math.Sqrt(1 / (double)(b.GetBeginAtom().ValenceNumber() * b.GetEndAtom().ValenceNumber()))).Sum();
        }

        /// <summary>
        /// Calculates the Hk deltas for the molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="skipHydrogens"></param>
        /// <returns></returns>
        public static double[] HkDeltas(this OBMol mol, bool skipHydrogens = true)
        {
            var numAtoms = mol.NumAtoms();
            var result = new double[numAtoms];
            for(var i = 1; i <= numAtoms; i++)
            {
                var atom = mol.GetAtom(i);
                var atomicNumber = atom.GetAtomicNum();
                if (atomicNumber > 1)
                {
                    result[i - 1] = atomicNumber <= 10 ? (double)atom.ValenceNumber() : (double)(atom.ValenceNumber() / (atomicNumber - atom.NOuterShellElectrons() - 1));
                }
                else if (!skipHydrogens)
                {
                    result[i - 1] = 0d;
                }
            }
            return result;
        }


        /// <summary>
        /// Perform depth limited search of each atom to a depth of length
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="length"></param>
        /// <param name="useHydrogens"></param>
        /// <returns></returns>
        public static IEnumerable<Path> PathsOfLengthN(this OBMol mol, int length, bool useHydrogens = false)
        {

            var newMol = useHydrogens ? mol.AddExplicitHydrogens() : mol;
            var paths = new List<Path>();
            
            foreach (var atom in newMol.Atoms())
            {
                var foundPaths = new List<IEnumerable<OBAtom>>();
                var currentPath = new List<OBAtom>();
                Search.DepthLimitedSearch(atom, length, currentPath, ref foundPaths);
                foreach (var foundPath in foundPaths)
                {
                    if (foundPath.Count() == length + 1)
                    {
                        paths.Add(new Path(foundPath));
                    }
                }
            }
            return paths.Distinct(new PathComparer());
            
        }

        /// <summary>
        /// Calculates Hall-Kier alpha value for a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double HallKierAlpha(this OBMol mol)
        {
            var accum = 0.0;
            foreach(var atom in mol.Atoms())
            {
                uint atomicNumber;
                try
                {
                    atomicNumber = atom.GetAtomicNum();
                }
                catch (Exception)
                {
                    continue;
                }
                double alpha;
                var hkAlphas = AtomicConstants.GetHallKierAlphas(atomicNumber);
                if (hkAlphas != null)
                {
                    var hyb = atom.Hybridization() - 2;
                    var length = hkAlphas.Length;
                    alpha = hyb < length ? (hkAlphas[hyb].HasValue ? hkAlphas[hyb].Value : hkAlphas[length - 1].Value) : hkAlphas[length - 1].Value;
                }
                else
                {
                    alpha = AtomicConstants.GetrVdW(atomicNumber) / AtomicConstants.GetrVdW(6) - 1;
                }
                accum += alpha;
            }
            return accum;
        }

        /// <summary>
        /// Calculates the characteristic polynomial for a molecular graph (molecule)
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[] CharacteristicPolynomial(this OBMol mol, Matrix matrix)
        {
            var An = matrix.Copy();
            var numAtoms = mol.NumAtoms();
            var identity = Matrix.Identity((int)numAtoms, (int)numAtoms);
            var result = new double[numAtoms + 1].Zero().ToArray();
            result[0] = 1.0;
            for (var i = 1; i < result.Length; i++)
            {
                result[i] = 1d / (double)i * An.Trace();
                var Bn = An.Subtract(identity.Multiply(result[i]));
                An = matrix.Multiply(Bn);
            }
            for (var i = 1; i < result.Length; i++)
            {
                result[i] *= -1;
            }
            return result;
        }
    }
}
