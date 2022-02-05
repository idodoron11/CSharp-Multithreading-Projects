using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Matrix
    {
        double[,] matrix;
        internal bool transpose;

        public Matrix(double[,] matrix)
        {
            this.matrix = (double[,]) matrix.Clone();
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
    }
}
