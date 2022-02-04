using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class SudokuBoard
    {
        int[,] board;

        public SudokuBoard()
        {
            board = new int[9,9];
        }

        public int getCell(int row, int column)
        {
            if (row >= 9)
                throw new ArgumentException("Row must be between 0 and 8");
            if (column >= 9)
                throw new ArgumentException("Column must be between 0 and 8");
            return this.board[row,column];
        }

        public void setCell(int row, int column, int value)
        {
            if (row >= 9 || row < 0)
                throw new ArgumentException("Row must be between 0 and 8");
            if (column >= 9 || column < 0)
                throw new ArgumentException("Column must be between 0 and 8");
            if (value < 1 || value > 9)
                throw new ArgumentException("A cell can only contain integers between 1 and 9");
            this.board[row,column] = value;
        }

        public void resetCell(int row, int column)
        {
            if (row >= 9 || row < 0)
                throw new ArgumentException("Row must be between 0 and 8");
            if (column >= 9 || column < 0)
                throw new ArgumentException("Column must be between 0 and 8");
            this.board[row,column] = 0;
        }

        public bool isValid()
        {
            for (int i = 0; i < 9; ++i)
            {
                if (!isSegmentValid(rowEnumerator(i)))
                {
                    return false;
                }
                else if (!isSegmentValid(columnEnumerator(i)))
                {
                    return false;
                }
                else if (!isSegmentValid(blockEnumerator(i)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isSegmentValid(IEnumerable<int> segment)
        {
            bool[] found = new bool[9];
            foreach (int cell in segment)
            {
                if (found[cell])
                {
                    return false;
                }
                else
                {
                    found[cell] = true;
                }
            }
            return true;
        }

        public IEnumerable<int> rowEnumerator(int row)
        {
            if (row >= 9 || row < 0)
                throw new ArgumentException("Row must be between 0 and 8");
            for (int column = 0; column < 9; ++column)
            {
                yield return board[row,column];
            }
        }

        public IEnumerable<int> columnEnumerator(int column)
        {
            if (column >= 9 || column < 0)
                throw new ArgumentException("Column must be between 0 and 8");
            for (int row = 0; row < 9; ++row)
            {
                yield return board[row,column];
            }
        }

        public IEnumerable<int> blockEnumerator(int block)
        {
            if (block >= 9 || block < 0)
                throw new ArgumentException("Block must be between 0 and 8");
            int row, column;
            switch (block) {
                case 0: row = 0; column = 0; break;
                case 1: row = 0; column = 3; break;
                case 2: row = 0; column = 6; break;
                case 3: row = 3; column = 0; break;
                case 4: row = 3; column = 3; break;
                case 5: row = 3; column = 6; break;
                case 6: row = 6; column = 0; break;
                case 7: row = 6; column = 3; break;
                case 8: row = 6; column = 6; break;
                default: row = 0; column = 0; break;
            }
            for (int i = row; i < row + 3; ++i)
            {
                for (int j = column; j < column + 3; ++j)
                {
                    yield return board[i,j];
                }
            }
        }
    }
}
