using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;

namespace OBDescriptorExtension
{
    class FloydWarshall
    {
        #region Privates

        private const int nil = -1;
        private OBMol _mol;
        private bool _useBondOrder;
        private bool _useAtomicNumber;
        private Matrix _distanceMatrix;
        private Matrix _predecessorMatrix;

        #endregion

        #region Properties

        public static readonly double MaxValue = 100000000;

        private OBMol Mol
        {
            get { return this._mol; }
        }

        /// <summary>
        /// Matrix holding intermediate atoms indices along shortest paths
        /// </summary>
        public Matrix PredecessorMatrix
        {
            get
            {
                if (this._predecessorMatrix == null)
                {
                    this.Compute(this._useBondOrder, this._useAtomicNumber);
                }
                return this._predecessorMatrix;
            }

        }

        /// <summary>
        /// All pairs shortest path matrix
        /// </summary>
        public Matrix DistanceMatrix
        {
            get
            {
                if (this._distanceMatrix == null)
                {
                    this.Compute(this._useBondOrder, this._useAtomicNumber);
                }
                return this._distanceMatrix;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Computes the all-pairs shortest paths of a molecule using the Floyd-Warshall algorithm
        /// </summary>
        /// <param name="useBondOrder"></param>
        /// <param name="useAtomicNumber"></param>
        private void Compute(bool useBondOrder, bool useAtomicNumber)
        {
            var numAtoms = this.Mol.NumAtoms();
            this._distanceMatrix = new Matrix((int)numAtoms, (int)numAtoms);
            this._predecessorMatrix = new Matrix((int)numAtoms, (int)numAtoms);

            // Initialize matrix
            for (var i = 0; i < numAtoms; i++)
            {
                for (var j = 0; j < numAtoms; j++)
                {
                    if (i == j)
                    {
                        this._distanceMatrix.Update(i, j, 0);
                    }
                    else
                    {
                        var bond = this.Mol.GetBond(this.Mol.GetAtom(i + 1), this.Mol.GetAtom(j + 1));
                        double contrib = bond == null ? MaxValue : 1;
                        if (useBondOrder)
                        {
                            contrib = bond != null ? (bond.IsAromatic() ? 2d / 3d : 1d / (double)bond.GetBondOrder()) : MaxValue;
                        }
                        this._distanceMatrix.Update(i, j, contrib);
                    }
                    this._predecessorMatrix.Update(i, j, nil);
                }
            }


            // Compute minimum distance
            for(var k = 0; k < numAtoms; k++)
            {
                for (var i = 0; i < numAtoms; i++)
                {
                    for (var j = 0; j < numAtoms; j++)
                    {
                        if (this._distanceMatrix.Get(i, k) + this._distanceMatrix.Get(k, j) < this._distanceMatrix.Get(i, j))
                        {
                            this._distanceMatrix.Update(i, j, this._distanceMatrix.Get(i, k) + this._distanceMatrix.Get(k, j));
                            this._predecessorMatrix.Update(i, j, k);
                        }
                    }
                }
            }

            if (useAtomicNumber)
            {
                for (var i = 0; i < numAtoms; i++)
                {
                    this._distanceMatrix.Update(i, i, 6.0 / this.Mol.GetAtom(i + 1).GetAtomicNum());
                }
            }
        }

        /// <summary>
        /// Recursively finds the connecting atoms between start and end atoms in a path
        /// </summary>
        /// <param name="path"></param>
        //private Path FindPath(int startIdx, int endIdx)
        //{
        //    if (this._distanceMatrix.Get(startIdx, endIdx) == MaxValue)
        //    {
        //        return null;
        //    }
        //    var intermediate = this._predecessorMatrix.Get(startIdx, endIdx);
        //    if (intermediate == nil)
        //    {
        //        return " ";
        //    }
        //    else
        //    {
        //        return this.FindPath(startIdx, (int)intermediate) + intermediate.ToString() + this.FindPath((int)intermediate, endIdx);
        //    }
        //}

        #endregion

        #region Constructor

        public FloydWarshall(OBMol mol, bool useBondOrder, bool useAtomicNumber)
        {
            this._mol = mol;
            this._useBondOrder = useBondOrder;
            this._useAtomicNumber = useAtomicNumber;
        }

        #endregion

    }
}
