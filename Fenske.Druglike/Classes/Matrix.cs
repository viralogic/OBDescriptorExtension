using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension
{
    public class Matrix
    {
        #region Private variables

        private double[,] _matrix;
        private int _rows = -1;
        private int _cols = -1;

        #endregion

        #region Properties

        /// <summary>
        /// The matrix
        /// </summary>
        private double[,] Mat
        {
            get { return this._matrix; }
        }

        /// <summary>
        /// Number of rows in the matrix
        /// </summary>
        public int Rows
        {
            get 
            {
                if (this._rows == -1)
                {
                    this._rows = this.Mat.GetLength(0);
                }
                return this._rows; 
            }
        }

        /// <summary>
        /// Number of columns in the matrix
        /// </summary>
        public int Cols
        {
            get 
            {
                if (this._cols == -1)
                {
                    this._cols = this.Mat.GetLength(1);
                }
                return this._cols; 
            }
        }

        #endregion

        #region Constructor

        public Matrix(int rows, int cols)
        {
            this._matrix = new double[rows, cols];
            this.Init();
        }

        public Matrix(double[,] matrix)
        {
            this._matrix = matrix;
        }

        #endregion

        #region Methods

        private void Init()
        {
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    this.Update(i, j, 0);
                }
            }
        }

        private bool IsValidPosition(int i, int j)
        {
            return !(i >= this.Rows || j >= this.Cols || i < 0 || j < 0);
        }

        /// <summary>
        /// Updates an element at the specified indices with given value
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Update(int i, int j, double value)
        {
            if (!this.IsValidPosition(i, j))
            {
                throw new IndexOutOfRangeException(string.Format("{0} or {1} is not a valid index", i, j));
            }
            this.Mat[i, j] = value;
        }

        /// <summary>
        /// Gets an element at the specified indices
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public double Get(int i, int j)
        {
            if (!this.IsValidPosition(i, j))
            {
                throw new IndexOutOfRangeException(string.Format("{0} or {1} is not a valid index", i, j));
            }
            return this.Mat[i, j];
        }

        /// <summary>
        /// Adds scalar amount to each element in matrix
        /// </summary>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public Matrix Add(double scalar)
        {
            var newMatrix = new Matrix(this.Rows, this.Cols);
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    newMatrix.Update(i, j, this.Get(i, j) + scalar);
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Multiplies the elements in a matrix by a scalar amount
        /// </summary>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public Matrix Multiply(double scalar)
        {
            var newMatrix = new Matrix(this.Rows, this.Cols);
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    newMatrix.Update(i, j, this.Get(i, j) * scalar);
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Element-wise addition of a given matrix to a source matrix
        /// </summary>
        /// <param name="source"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public Matrix Add(Matrix matrix2)
        {
            if (this.Rows != matrix2.Rows || this.Cols != matrix2.Rows)
            {
                throw new ArgumentException("The argument matrix does not have same number rows or columns as source matrix.");
            }
            var newMatrix = new Matrix(this.Rows, this.Cols);
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    newMatrix.Update(i, j, this.Get(i, j) + matrix2.Get(i, j));
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Element-wise subtraction of a given matrix from a source matrix
        /// </summary>
        /// <param name="source"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public Matrix Subtract(Matrix matrix2)
        {
            return this.Add(matrix2.Multiply(-1));
        }

        /// <summary>
        /// Returns identity matrix with same rows and columns as source as a copy (not in place).
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Matrix Identity(int rows, int cols)
        {
            var newMatrix = new Matrix(rows, cols);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    newMatrix.Update(i, j, i == j ? 1 : 0);
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Calculates the trace (sum of the diagonal) of a matrix
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public double Trace()
        {
            double sum = 0;
            for (var i = 0; i < this.Rows; i++)
            {
                sum += this.Get(i, i);
            }
            return sum;
        }

        /// <summary>
        /// Multiplication of matrix instance with another matrix instance
        /// </summary>
        /// <param name="source"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public Matrix Multiply(Matrix matrix2)
        {
            if (this.Cols != matrix2.Rows)
            {
                throw new ArgumentException("The source and argument matrices cannot be multiplied");
            }
            var newMatrix = new Matrix(this.Rows, this.Cols);
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < matrix2.Cols; j++)
                {
                    double sum = 0;
                    for (var k = 0; k < this.Cols; k++)
                    {
                        sum += this.Get(i, k) * matrix2.Get(k, j);
                    }
                    newMatrix.Update(i, j, sum);
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Marks elements in matrix with 1 if element equals value, else 0
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Matrix Filter(double value)
        {
            var newMatrix = new Matrix(this.Rows, this.Cols);
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    newMatrix.Update(i, j, this.Get(i, j) == value ? 1 : 0);
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Performs a deep copy of the matrix instance
        /// </summary>
        /// <returns></returns>
        public Matrix Copy()
        {
            var newMatrix = new Matrix(this.Rows, this.Cols);
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    newMatrix.Update(i, j, this.Get(i, j));
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// Performs row sum of matrix
        /// </summary>
        /// <returns></returns>
        public IEnumerable<double> RowSum()
        {
            var result = new double[this.Rows].Zero().ToArray();
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                {
                    result[i] += this.Get(i, j);
                }
            }
            return result;
        }

        #endregion
    }
}
