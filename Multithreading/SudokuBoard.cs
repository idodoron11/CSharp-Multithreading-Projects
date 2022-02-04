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
            object _lock = new object();
            bool result = true;

            // Define 27 threads without starting them yet.
            Thread[] rowThread = new Thread[9];
            Thread[] columnThread = new Thread[9];
            Thread[] blockThread = new Thread[9];
            for (int i = 0; i < 9; ++i)
            {
                int iteration = i;
                rowThread[i] = new Thread(() => { threadWork(rowEnumerator(iteration), _lock, ref result); });
                columnThread[i] = new Thread(() => { threadWork(columnEnumerator(iteration), _lock, ref result); });
                blockThread[i] = new Thread(() => { threadWork(blockEnumerator(iteration), _lock, ref result); });
            }

            // Start threads
            for (int i = 0; i < 9; ++i)
            {
                rowThread[i].Start();
                columnThread[i].Start();
                blockThread[i].Start();
            }

            // Wait for threads termination
            for (int i = 0; i < 9; ++i)
            {
                rowThread[i].Join();
                columnThread[i].Join();
                blockThread[i].Join();
            }

            return result;
        }

        private void threadWork(IEnumerable<int> segment, object _lock, ref bool result)
        {
            if (!isSegmentValid(segment))
            {
                lock (_lock)
                {
                    result = false;
                }
            }
        }

        private bool isSegmentValid(IEnumerable<int> segment)
        {
            bool[] found = new bool[9];
            foreach (int cell in segment)
            {
                if (found[cell - 1])
                {
                    return false;
                }
                else
                {
                    found[cell - 1] = true;
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
