using NUnit.Framework;

namespace Multithreading.UnitTests
{
    public class MatrixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAndSetTest()
        {
            double[,] arr = new double[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[i, j] = (i+1) * (j+1);
                }
            }

            // Ensure matrix cells values are as expected.
            Matrix matrix = new Matrix(arr);

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Assert.AreEqual((i + 1) * (j + 1), matrix.Get(i, j));
                    arr[i, j] = 0; // Changing `arr` cell values should affect `matrix`.
                }
            }

            // Ensure no one can change the matrix values from outside the class.
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Assert.AreEqual((i + 1) * (j + 1), matrix.Get(i, j));
                }
            }
        }


        [Test]
        public void TransposeTest()
        {
            double[,] arr = new double[,] {
                { 1,2,3,4,5 },
                { 6, 7,8,9,10 },
                { 11, 12, 13, 14, 15 }
            };
            Matrix matrix = new Matrix(arr);

            matrix.Transpose();
            for (int i = 0; i < matrix.GetHeight(); ++i)
            {
                for (int j = 0; j < matrix.GetWidth(); ++j)
                {
                    Assert.AreEqual(arr[j, i], matrix.Get(i, j));
                }
            }
        }
    }
}
