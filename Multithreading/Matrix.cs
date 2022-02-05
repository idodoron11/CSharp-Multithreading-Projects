using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Matrix
    {
        internal double[,] matrix;
        internal bool transpose;

        public Matrix(double[,] matrix)
        {
            this.matrix = (double[,]) matrix.Clone();
        }

        protected Matrix(double[] vector)
        {
            double[,] matrix = new double[vector.GetLength(0), 1];
            for (int i = 0; i < vector.GetLength(0); ++i)
            {
                matrix[i, 0] = vector[i];
            }
            this.matrix = matrix;
        }

        public void Transpose()
        {
            transpose = !transpose;
        }

        protected void ValidateVectorAccess(int x, int y)
        {
            int height = this.GetHeight();
            int width = this.GetWidth();

            if (x < 0 || x >= height || y < 0 || y >= width)
            {
                throw new IndexOutOfRangeException(String.Format("Illegal matrix cell access at ({0}, {1}).", x, y));
            }
        }

        public double Get(int x, int y)
        {
            ValidateVectorAccess(x, y);
            if (transpose)
            {
                int temp = x;
                x = y;
                y = temp;
            }

            return this.matrix[x, y];
        }

        public int GetHeight()
        {
            if (transpose)
            {
                return this.matrix.GetLength(1);
            }
            else
            {
                return this.matrix.GetLength(0);
            }
        }

        public int GetWidth()
        {
            if (!transpose)
            {
                return this.matrix.GetLength(1);
            }
            else
            {
                return this.matrix.GetLength(0);
            }
        }

        public Matrix MultiplyBy(Matrix other)
        {
            throw new NotImplementedException();
        }

        private static double MultiplyRowByColumn(Matrix left, Matrix right, int row, int col)
        {
            double result = 0;
            for (int index = 0; index < left.GetWidth(); ++index)
            {
                result += left.Get(row, index) * right.Get(index, col);
            }
            return result;
        }

        public Matrix NaiveMultiplyBy(Matrix other)
        {
            if (other == null)
                throw new ArgumentNullException();
            if (this.GetWidth() != other.GetHeight())
                throw new ArgumentException("Left matrix width should be the same as the right matrix height");

            int resultHeight = this.GetHeight(), resultWidth = other.GetWidth();
            double[,] result = new double[resultHeight, resultWidth];

            for (int row = 0; row < resultHeight; row++)
            {
                for (int col = 0; col < resultWidth; ++col)
                {
                    // we multiply `this` row vector number `row` by `other` column vector number `col`.
                    // we store the result at `result[row, col]`
                    result[row, col] += MultiplyRowByColumn(this, other, row, col);
                }
            }

            return new Matrix(result);
        }
    }

    internal class Vector : Matrix
    {
        public Vector(params double[] vector) : base(vector)
        {
        }

        public double Get(int index)
        {
            return this.matrix[index, 0];
        }
    }
}
