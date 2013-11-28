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
        private static double[] LabuteASAContributions(this OBMol mol, bool includeHydrogens=true)
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
        /// Computes the Labute surface area of a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="includeHydrogens">Include hydrogen contributions (bool)</param>
        /// <returns></returns>
        public static double LabuteAsa(this OBMol mol, bool includeHydrogens = true)
        {
            return mol.LabuteASAContributions(includeHydrogens).Sum();
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
        /// Calculates the PEOE VSA contributions from each atom
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] PeoeVsaContributions(this OBMol mol)
        {
            var chargedMol = mol.AssignGasteigerCharges();
            var atoms = chargedMol.Atoms().Where(a => a.IsHeavyAtom());
            var volContribs = mol.LabuteASAContributions();
            var result = new double[BinConstants.AtomicChargeBins.Length + 1].Zero().ToArray();
            var i = 0;
            foreach(var atom in atoms)
            {
                var partialCharge = atom.GetPartialCharge();
                var bin = BinConstants.AtomicChargeBins.BisectRight(partialCharge);
                if (bin > -1)
                {
                    result[bin] += volContribs[i + 1];
                }
                i++;
            }
            return result;
        }

        /// <summary>
        /// Calculates the Crippen SMR VSA contributions from each atom
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        private static double[] CrippenSmrVsaContributions(this OBMol mol, bool includeHydrogens)
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
        /// Calculates the Crippen SMR VSA for molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double CrippenSmrVSA(this OBMol mol)
        {
            return mol.CrippenSmrVsaContributions(true).Sum();
        }

        /// <summary>
        /// Calculates the Crippen SLogP VSA contributions from each atom
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        private static double[] CrippenSLogPVsaContributions(this OBMol mol, bool includeHydrogens)
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
        /// Calculates the Crippen SLogP VSA for molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double CrippenSLogPVSA(this OBMol mol)
        {
            return mol.CrippenSLogPVsaContributions(true).Sum();
        }

        /// <summary>
        /// Calculates Labute SMR VSA for molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] LabuteSmrVSA(this OBMol mol)
        {
            var result = new double[BinConstants.LabuteMrBins.Length + 1].Zero().ToArray();
            var crippenContribs = mol.CrippenSmrVsaContributions(false);
            var labuteContribs = mol.LabuteASAContributions();
            for (var i = 0; i < crippenContribs.Length; i++)
            {
                var bin = BinConstants.LabuteMrBins.BisectRight(crippenContribs[i]);
                if (bin > -1)
                {
                    result[bin] += labuteContribs[i + 1];
                }
            }
            return result;
        }

        /// <summary>
        /// Calculates the Labute SLogP VSA for the molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] LabuteSLogPVSA(this OBMol mol)
        {
            var result = new double[BinConstants.LabuteLogPBins.Length + 1].Zero().ToArray();
            var crippenContribs = mol.CrippenSLogPVsaContributions(false);
            var labuteContribs = mol.LabuteASAContributions();
            for (var i = 0; i < crippenContribs.Length; i++)
            {
                var bin = BinConstants.LabuteLogPBins.BisectRight(crippenContribs[i]);
                if (bin > -1)
                {
                    result[bin] += labuteContribs[i + 1];
                }
            }
            return result;
        }

        /// <summary>
        /// Computes the all-pairs minimum distance matrix for a molecular graph (molecule)
        /// </summary>
        /// <param name="mol">OBMol</param>
        /// <returns>double[,] with equal rows and columns</returns>
        public static Matrix DistanceMatrix(this OBMol mol, bool useBondOrder=false, bool useAtomicNumber=false)
        {
            return new FloydWarshall(mol, useBondOrder, useAtomicNumber).DistanceMatrix;
        }

        /// <summary>
        /// Computes the EState for each atom in molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] EStateIndices(this OBMol mol)
        {
            var numAtoms = mol.NumAtoms();
            var Is = new double[numAtoms].Zero().ToArray();
            for (var i = 1; i <= numAtoms; i++)
            {
                var atom = mol.GetAtom(i);
                var degree = atom.GetValence();
                if (degree > 0)
                {
                    var dv = atom.NOuterShellElectrons() - atom.TotalNumHydrogens();
                    var N = atom.PrincipleQuantumNumber();
                    Is[i-1] = (4 / (N * N) * dv + 1) / (double)degree;
                }
            }
            var distances = mol.DistanceMatrix().Add(1);
            var accum = new double[numAtoms].Zero().ToArray();
            for (var i = 0; i < numAtoms; i++)
            {
                for (var j = i + 1; j < numAtoms; j++)
                {
                    var p = distances.Get(i, j);
                    if (p < FloydWarshall.MaxValue)
                    {
                        var temp = (Is[i] - Is[j]) / (p * p);
                        accum[i] += temp;
                        accum[j] -= temp;
                    }
                }
            }
            return Is.Add(accum).ToArray();
        }

        /// <summary>
        /// VSA EState contribution for each atom in a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] VsaEState(this OBMol mol)
        {
            var propContribs = mol.EStateIndices();
            var vsaContribs = mol.LabuteASAContributions();
            var result = new double[BinConstants.EStateBins.Length + 1].Zero().ToArray();
            for (var i = 0; i < propContribs.Length; i++)
            {
                var bin = BinConstants.EStateBins.BisectRight(vsaContribs[i + 1]);
                if (bin > -1)
                {
                    result[bin] += propContribs[i];
                }
            }
            return result;
        }

        /// <summary>
        /// EState Vsa contribution for each atom in a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double[] EStateVsa(this OBMol mol)
        {
            var propContribs = mol.EStateIndices();
            var vsaContribs = mol.LabuteASAContributions();
            var result = new double[BinConstants.EStateBins.Length + 1].Zero().ToArray();
            for (var i = 0; i < propContribs.Length; i++)
            {
                var bin = BinConstants.EStateBins.BisectRight(propContribs[i]);
                if (bin > -1)
                {
                    result[bin] += vsaContribs[i + 1];
                }
            }
            return result;
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
        private static double[] HkDeltas(this OBMol mol, bool skipHydrogens = true)
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
        /// ChiNv atomic valence connectivity index (order N)
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="length">length of the paths to find</param>
        /// <returns></returns>
        public static double ChiNv(this OBMol mol, int length)
        {
            var deltas = mol.HkDeltas(false).Select(d => d == 0 ? 0 : 1 / Math.Sqrt(d)).ToArray();
            var paths = mol.PathsOfLengthN(length);
            var sum = 0d;
            foreach (var path in paths)
            {
                sum += path.PathAtoms.Select(a => deltas[a.GetIdx() - 1]).Aggregate((a, b) => a * b);
            }
            return sum;
        }

        /// <summary>
        /// ChiNn atomic valence number connectivity index (order N)
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="length">Length of the paths to find</param>
        /// <returns></returns>
        public static double ChiNn(this OBMol mol, int length)
        {
            var deltas = mol.Atoms().Select(a => a.ValenceNumber()).Select(i => i == 0 ? 0 : 1 / Math.Sqrt(i)).ToArray();
            var paths = mol.PathsOfLengthN(length);
            double sum = 0;
            foreach (var path in paths)
            {
                sum += path.PathAtoms.Select(a => deltas[a.GetIdx() - 1]).Aggregate((a, b) => a * b);
            }
            return sum;

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
        /// Hall-Kier Kappa 1 value for a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Kappa1(this OBMol mol)
        {
            var p1 = mol.Bonds().Where(b => !b.GetBeginAtom().IsHydrogen() && !b.GetEndAtom().IsHydrogen()).Count();
            var atoms = mol.NumHvyAtoms();
            var alpha = mol.HallKierAlpha();
            var denominator = p1 + alpha;
            return denominator != 0 ? ((atoms + alpha) * Math.Pow((atoms + alpha - 1), 2)) / Math.Pow(denominator, 2) : 0.0;
        }

        /// <summary>
        /// Hall-Kier Kappa 2 value for a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Kappa2(this OBMol mol)
        {
            var p2 = mol.PathsOfLengthN(2).Count();
            var atoms = mol.NumHvyAtoms();
            var alpha = mol.HallKierAlpha();
            var denominator = p2 + alpha;
            return denominator != 0 ? ((atoms + alpha - 1) * Math.Pow((atoms + alpha - 2), 2)) / Math.Pow(denominator, 2) : 0.0;
        }

        /// <summary>
        /// Hall-Kier Kappa 3 value for a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static double Kappa3(this OBMol mol)
        {
            var p3 = mol.PathsOfLengthN(3).Count();
            var atoms = mol.NumHvyAtoms();
            var alpha = mol.HallKierAlpha();
            var denominator = p3 + alpha;
            if (denominator != 0)
            {
                return atoms % 2 == 1
                    ? ((atoms + alpha - 1) * Math.Pow((atoms + alpha - 3), 2)) / Math.Pow(denominator, 2)
                    : ((atoms + alpha - 2) * Math.Pow((atoms + alpha - 3), 2)) / Math.Pow(denominator, 2);
            }
            return 0;
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

        /// <summary>
        /// Produces the adjacency matrix for a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        public static Matrix AdjacencyMatrix(this OBMol mol)
        {
            var distanceMatrix = mol.DistanceMatrix();
            return distanceMatrix.Filter(1);
        }

        /// <summary>
        /// Calculates the information content of the coefficients of the characteristic 
        /// polynomial of the adjacency matrix of a hydrogen-suppressed graph of a molecule.
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="average"></param>
        /// <returns></returns>
        public static double Ipc(this OBMol mol, bool average = false)
        {
            var adjMatrix = mol.AdjacencyMatrix();
            var cPoly = mol.CharacteristicPolynomial(adjMatrix).Abs();
            if (average)
            {
                return cPoly.InfoEntropy();
            }
            return cPoly.Sum() * cPoly.InfoEntropy();
        }

        /// <summary>
        /// Calculates Balaban's J value for a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns>double</returns>
        public static double BalabanJ(this OBMol mol)
        {
            var adjMat = mol.AdjacencyMatrix();
            var numBonds = mol.NumBonds();
            var numAtoms = mol.NumAtoms();
            var mu = numBonds - numAtoms + 1;
            if (mu + 1 == 0)
            {
                return 0;
            }

            var vertexDegreeSum = mol.DistanceMatrix(useBondOrder: true).RowSum().ToArray();
            double accum = 0;
            for (var i = 0; i < numAtoms; i++)
            {
                for (var j = i; j < numAtoms; j++)
                {
                    if (adjMat.Get(i, j) == 1d)
                    {
                        accum += 1d / Math.Sqrt(vertexDegreeSum[i] * vertexDegreeSum[j]);
                    }
                }
            }

            return (double)numBonds / (double)(mu + 1) * accum;
        }
    }
}
