using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;
using OBDescriptorExtension.Constants;

namespace OBDescriptorExtension
{
    public class OBMolExtended
    {

        #region Privates

        private OBMol _mol;

        private Matrix _distanceMatrix;
        private double[] _labuteAsaContributions;
        private double[] _crippenSmrVsaContributions;
        private double[] _crippenSLogPVsaContributions;

        private double[] _vsaEState;
        private double[] _eStateVsa;
        private double[] _peoeVsa;
        private double[] _smrVsa;
        private double[] _sLogPVsa;
        private double[] _eStateIndices;

        private double[] _hkDeltasNv;
        private double[] _hkDeltasNn;

        private double? _hallKierAlpha;

        #endregion

        #region Properties

        public OBMol Mol
        {
            get { return this._mol; }
        }

        public double[] LabuteAsaContributions
        {
            get
            {
                if (this._labuteAsaContributions == null)
                {
                    this._labuteAsaContributions = this.Mol.LabuteASAContributions();
                }
                return this._labuteAsaContributions;
            }
        }

        private double[] CrippenSmrVsaContributions
        {
            get
            {
                if (this._crippenSmrVsaContributions == null)
                {
                    this._crippenSmrVsaContributions = this.Mol.CrippenSmrVsaContributions(false);
                }
                return this._crippenSmrVsaContributions;
            }
        }

        private double[] CrippenSLogVsaContributions
        {
            get
            {
                if (this._crippenSLogPVsaContributions == null)
                {
                    this._crippenSLogPVsaContributions = this.Mol.CrippenSLogPVsaContributions(false);
                }
                return this._crippenSLogPVsaContributions;
            }
        }

        private double[] HkDeltasNv
        {
            get
            {
                if (this._hkDeltasNv == null)
                {
                    this._hkDeltasNv = this.Mol.HkDeltas(false).Select(d => d == 0 ? 0 : 1 / Math.Sqrt(d)).ToArray();
                }
                return this._hkDeltasNv;
            }
        }

        private double[] HkDeltasNn
        {
            get
            {
                if (this._hkDeltasNn == null)
                {
                    this._hkDeltasNn = this.Mol.Atoms().Select(a => a.ValenceNumber()).Select(i => i == 0 ? 0 : 1 / Math.Sqrt(i)).ToArray();
                }
                return this._hkDeltasNn;
            }
        }

        public double[] VsaEState
        {
            get
            {
                if (this._vsaEState == null)
                {
                    this._vsaEState = this.CalculateVsaEState();
                }
                return this._vsaEState;
            }
        }

        public double[] EStateVsa
        {
            get
            {
                if (this._eStateVsa == null)
                {
                    this._eStateVsa = this.CalculateEStateVsa();
                }
                return this._eStateVsa;
            }
        }

        public double[] PeoeVsa
        {
            get
            {
                if (this._peoeVsa == null)
                {
                    this._peoeVsa = this.PeoeVsaContributions();
                }
                return this._peoeVsa;
            }
        }

        public double[] SmrVsa
        {
            get
            {
                if (this._smrVsa == null)
                {
                    this._smrVsa = this.LabuteSmrVSA();
                }
                return this._smrVsa;
            }
        }

        public double[] SLogPVsa
        {
            get
            {
                if (this._sLogPVsa == null)
                {
                    this._sLogPVsa = this.LabuteSLogPVSA();
                }
                return this._sLogPVsa;
            }
        }

        private double[] EStateIndices
        {
            get
            {
                if (this._eStateIndices == null)
                {
                    this._eStateIndices = this.CalculateEStateIndices();
                }
                return this._eStateIndices;
            }
        }

        /// <summary>
        /// All-pairs shortest path matrix computed using Floyd-Warshall algorithm
        /// </summary>
        public Matrix DistanceMatrix
        {
            get
            {
                if (this._distanceMatrix == null)
                {
                    this._distanceMatrix = new FloydWarshall(this.Mol, false, false).DistanceMatrix;
                }
                return this._distanceMatrix;
            }
        }

        /// <summary>
        /// Hall-Kier alpha value for a molecule
        /// </summary>
        public double HallKierAlpha
        {
            get
            {
                if (!this._hallKierAlpha.HasValue)
                {
                    this._hallKierAlpha = this.Mol.HallKierAlpha();
                }
                return this._hallKierAlpha.Value;
            }
        }

        /// <summary>
        /// Hall-Kier Kappa 1 value for a molecule
        /// </summary>
        /// <returns></returns>
        public double Kappa1
        {
            get
            {
                var p1 = this.Mol.Bonds().Where(b => !b.GetBeginAtom().IsHydrogen() && !b.GetEndAtom().IsHydrogen()).Count();
                var atoms = this.Mol.NumHvyAtoms();
                var denominator = p1 + this.HallKierAlpha;
                return denominator != 0 ? ((atoms + this.HallKierAlpha) * Math.Pow((atoms + this.HallKierAlpha - 1), 2)) / Math.Pow(denominator, 2) : 0.0;
            }
        }

        /// <summary>
        /// Hall-Kier Kappa 2 value for a molecule
        /// </summary>
        /// <returns></returns>
        public double Kappa2
        {
            get
            {
                var p2 = this.Mol.PathsOfLengthN(2).Count();
                var atoms = this.Mol.NumHvyAtoms();
                var denominator = p2 + this.HallKierAlpha;
                return denominator != 0 ? ((atoms + this.HallKierAlpha - 1) * Math.Pow((atoms + this.HallKierAlpha - 2), 2)) / Math.Pow(denominator, 2) : 0.0;
            }
        }

        /// <summary>
        /// Hall-Kier Kappa 3 value for a molecule
        /// </summary>
        /// <returns></returns>
        public double Kappa3
        {
            get
            {
                var p3 = this.Mol.PathsOfLengthN(3).Count();
                var atoms = this.Mol.NumHvyAtoms();
                var denominator = p3 + this.HallKierAlpha;
                if (denominator != 0)
                {
                    return atoms % 2 == 1
                        ? ((atoms + this.HallKierAlpha - 1) * Math.Pow((atoms + this.HallKierAlpha - 3), 2)) / Math.Pow(denominator, 2)
                        : ((atoms + this.HallKierAlpha - 2) * Math.Pow((atoms + this.HallKierAlpha - 3), 2)) / Math.Pow(denominator, 2);
                }
                return 0;
            }
        }

        /// <summary>
        /// The adjacency matrix for the molecule
        /// </summary>
        public Matrix AdjacencyMatrix
        {
            get { return this.DistanceMatrix.Filter(1); }
        }

        /// <summary>
        /// Calculates Balaban's J value for a molecule
        /// </summary>
        /// <returns>double</returns>
        public double BalabanJ
        {
            get
            {
                var numBonds = this.Mol.NumBonds();
                var numAtoms = this.Mol.NumAtoms();
                var mu = numBonds - numAtoms + 1;
                if (mu + 1 == 0)
                {
                    return 0;
                }

                var vertexDegreeSum = new FloydWarshall(this.Mol, true, false).DistanceMatrix.RowSum().ToArray();
                double accum = 0;
                for (var i = 0; i < numAtoms; i++)
                {
                    for (var j = i; j < numAtoms; j++)
                    {
                        if (this.AdjacencyMatrix.Get(i, j) == 1d)
                        {
                            accum += 1d / Math.Sqrt(vertexDegreeSum[i] * vertexDegreeSum[j]);
                        }
                    }
                }

                return (double)numBonds / (double)(mu + 1) * accum;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// ChiNv atomic valence connectivity index (order N)
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="length">length of the paths to find</param>
        /// <returns></returns>
        public double ChiNv(int length)
        {
            var paths = this.Mol.PathsOfLengthN(length);
            var sum = 0d;
            foreach (var path in paths)
            {
                sum += path.PathAtoms.Select(a => this.HkDeltasNv[a.GetIdx() - 1]).Aggregate((a, b) => a * b);
            }
            return sum;
        }

        /// <summary>
        /// ChiNn atomic valence number connectivity index (order N)
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="length">Length of the paths to find</param>
        /// <returns></returns>
        public double ChiNn(int length)
        {
            var paths = this.Mol.PathsOfLengthN(length);
            double sum = 0;
            foreach (var path in paths)
            {
                sum += path.PathAtoms.Select(a => this.HkDeltasNn[a.GetIdx() - 1]).Aggregate((a, b) => a * b);
            }
            return sum;

        }

        /// <summary>
        /// Calculates the PEOE VSA contributions from each atom
        /// </summary>
        /// <returns></returns>
        private double[] PeoeVsaContributions()
        {
            var chargedMol = this.Mol.AssignGasteigerCharges();
            var atoms = chargedMol.Atoms().Where(a => a.IsHeavyAtom());
            var result = new double[BinConstants.AtomicChargeBins.Length + 1].Zero().ToArray();
            var i = 0;
            foreach (var atom in atoms)
            {
                var partialCharge = atom.GetPartialCharge();
                var bin = BinConstants.AtomicChargeBins.BisectRight(partialCharge);
                result[bin] += this.LabuteAsaContributions[i + 1];
                i++;
            }
            return result;
        }

        /// <summary>
        /// Calculates Labute SMR VSA for molecule
        /// </summary>
        /// <returns></returns>
        private double[] LabuteSmrVSA()
        {
            var result = new double[BinConstants.LabuteMrBins.Length + 1].Zero().ToArray();
            for (var i = 0; i < this.CrippenSmrVsaContributions.Length; i++)
            {
                var bin = BinConstants.LabuteMrBins.BisectRight(this.CrippenSmrVsaContributions[i]);
                result[bin] += this.LabuteAsaContributions[i + 1];
            }
            return result;
        }

        

        /// <summary>
        /// Calculates the Labute SLogP VSA for the molecule
        /// </summary>
        /// <returns></returns>
        private double[] LabuteSLogPVSA()
        {
            var result = new double[BinConstants.LabuteLogPBins.Length + 1].Zero().ToArray();
            for (var i = 0; i < this.CrippenSLogVsaContributions.Length; i++)
            {
                var bin = BinConstants.LabuteLogPBins.BisectRight(this.CrippenSLogVsaContributions[i]);
                result[bin] += this.LabuteAsaContributions[i + 1];
            }
            return result;
        }

        /// <summary>
        /// Computes the EState for each atom in molecule
        /// </summary>
        /// <returns></returns>
        private double[] CalculateEStateIndices()
        {
            var numAtoms = this.Mol.NumAtoms();
            var Is = new double[numAtoms].Zero().ToArray();
            for (var i = 1; i <= numAtoms; i++)
            {
                var atom = this.Mol.GetAtom(i);
                var degree = atom.GetValence();
                if (degree > 0)
                {
                    var dv = atom.NOuterShellElectrons() - atom.TotalNumHydrogens();
                    var N = atom.PrincipleQuantumNumber();
                    Is[i - 1] = (4 / (N * N) * dv + 1) / (double)degree;
                }
            }
            var distances = this.DistanceMatrix.Add(1);
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
        /// <returns></returns>
        private double[] CalculateVsaEState()
        {
            var result = new double[BinConstants.EStateBins.Length + 1].Zero().ToArray();
            for (var i = 0; i < this.EStateIndices.Length; i++)
            {
                var bin = BinConstants.EStateBins.BisectRight(this.LabuteAsaContributions[i + 1]);
                result[bin] += this.EStateIndices[i];
            }
            return result;
        }

        /// <summary>
        /// EState Vsa contribution for each atom in a molecule
        /// </summary>
        /// <param name="mol"></param>
        /// <returns></returns>
        private double[] CalculateEStateVsa()
        {
            var result = new double[BinConstants.EStateBins.Length + 1].Zero().ToArray();
            for (var i = 0; i < this.EStateIndices.Length; i++)
            {
                var bin = BinConstants.EStateBins.BisectRight(this.EStateIndices[i]);
                result[bin] += this.LabuteAsaContributions[i + 1];
            }
            return result;
        }

        /// <summary>
        /// Calculates the information content of the coefficients of the characteristic 
        /// polynomial of the adjacency matrix of a hydrogen-suppressed graph of a molecule.
        /// </summary>
        /// <param name="mol"></param>
        /// <param name="average"></param>
        /// <returns></returns>
        public double Ipc(bool average = false)
        {
            var cPoly = this.Mol.CharacteristicPolynomial(this.AdjacencyMatrix).Abs();
            if (average)
            {
                return cPoly.InfoEntropy();
            }
            return cPoly.Sum() * cPoly.InfoEntropy();
        }

        #endregion

        #region Constructor

        public OBMolExtended(OBMol mol)
        {
            this._mol = mol;
        }

        #endregion
    }
}
