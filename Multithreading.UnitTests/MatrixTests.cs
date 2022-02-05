using NUnit.Framework;
using System;

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

            Assert.AreEqual(3, matrix.GetWidth());
            Assert.AreEqual(5, matrix.GetHeight());
        }

        [Test]
        public void NaiveMultiplicationTest()
        {
            Matrix matrix = new Matrix(new double[,] {
                { 0, 2, 1 },
                { 0, 1, 0 },
                { -1, 3, 5}
            });

            Matrix vector = new Vector(10, 20, 30);

            Matrix result = matrix.NaiveMultiplyBy(vector); // result should be (70, 20, 200)^T
            Assert.AreEqual(70, result.Get(0,0));
            Assert.AreEqual(20, result.Get(1, 0));
            Assert.AreEqual(200, result.Get(2, 0));

            matrix.Transpose();
            vector.Transpose();
            result = vector.NaiveMultiplyBy(matrix);  // result should be (70, 20, 200)
            Assert.AreEqual(70, result.Get(0, 0));
            Assert.AreEqual(20, result.Get(0, 1));
            Assert.AreEqual(200, result.Get(0, 2));

            Assert.Throws<ArgumentException>(
                    () => { matrix.NaiveMultiplyBy(vector); }
                );
        }

        [Test]
        public void MultiplicationTest()
        {
            Matrix matrix = new Matrix(new double[,] {
                { 0, 2, 1 },
                { 0, 1, 0 },
                { -1, 3, 5}
            });

            Matrix vector = new Vector(10, 20, 30);

            Matrix result = matrix.MultiplyBy(vector); // result should be (70, 20, 200)^T
            Assert.AreEqual(70, result.Get(0, 0));
            Assert.AreEqual(20, result.Get(1, 0));
            Assert.AreEqual(200, result.Get(2, 0));

            matrix.Transpose();
            vector.Transpose();
            result = vector.MultiplyBy(matrix);  // result should be (70, 20, 200)
            Assert.AreEqual(70, result.Get(0, 0));
            Assert.AreEqual(20, result.Get(0, 1));
            Assert.AreEqual(200, result.Get(0, 2));

            Assert.Throws<ArgumentException>(
                    () => { matrix.MultiplyBy(vector); }
                );
        }
    }
}
