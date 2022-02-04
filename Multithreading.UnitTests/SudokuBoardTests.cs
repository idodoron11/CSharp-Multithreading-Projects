using NUnit.Framework;

namespace Multithreading.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GeneralTest()
        {
            int[,] arr = new int[,]
            {
                {0,0,0,2,6,0,7,0,1},
                {6,8,0,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,0,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformTest(arr, true);
        }

        [Test]
        public void BlockTest()
        {
            int[,] arr = new int[,]
            {
                {0,0,0,2,6,0,7,0,1},
                {6,8,1,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,0,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformTest(arr, false);
        }

        [Test]
        public void RowTest()
        {
            int[,] arr = new int[,]
            {
                {2,0,0,2,6,0,7,0,1},
                {6,8,0,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,0,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformTest(arr, false);
        }

        [Test]
        public void ColumnTest()
        {
            int[,] arr = new int[,]
            {
                {0,0,0,2,6,0,7,0,1},
                {6,8,0,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,2,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformTest(arr, false);
        }

        [Test]
        public void SlowGeneralTest()
        {
            int[,] arr = new int[,]
            {
                {0,0,0,2,6,0,7,0,1},
                {6,8,0,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,0,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformSlowTest(arr, true);
        }

        [Test]
        public void SlowBlockTest()
        {
            int[,] arr = new int[,]
            {
                {0,0,0,2,6,0,7,0,1},
                {6,8,1,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,0,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformSlowTest(arr, false);
        }

        [Test]
        public void SlowRowTest()
        {
            int[,] arr = new int[,]
            {
                {2,0,0,2,6,0,7,0,1},
                {6,8,0,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,0,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformSlowTest(arr, false);
        }

        [Test]
        public void SlowColumnTest()
        {
            int[,] arr = new int[,]
            {
                {0,0,0,2,6,0,7,0,1},
                {6,8,0,0,7,0,0,9,0},
                {1,9,0,0,0,4,5,0,0 },
                {8,2,0,1,0,0,0,4,0 },
                {0,0,4,6,0,2,9,0,0 },
                {0,5,0,0,0,3,0,2,8 },
                {0,0,9,3,0,0,0,7,4 },
                {0,4,0,0,5,2,0,3,6 },
                {7,0,3,0,1,8,0,0,0 }
            };
            PerformSlowTest(arr, false);
        }

        private void PerformTest(int[,] arr, bool expectedResult)
        {
            SudokuBoard board = new SudokuBoard(arr);
            Assert.AreEqual(expectedResult, board.isValid());
        }

        private void PerformSlowTest(int[,] arr, bool expectedResult)
        {
            SudokuBoard board = new SudokuBoard(arr);
            Assert.AreEqual(expectedResult, board.slowIsValid());
        }
    }
}