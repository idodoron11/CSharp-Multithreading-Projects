using System;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SudokuBoard board = new SudokuBoard();
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    board.setCell(i, j, i + 1);
                }
            }

            Console.WriteLine(board.isValid());
        }
    }
}