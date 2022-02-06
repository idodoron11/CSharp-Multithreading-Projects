using NUnit.Framework;

namespace Multithreading.UnitTests
{
    public class PerfectCircleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int[,] arr = new int[3, 3];
            int[,] expectedResult = new int[,]
            {
                { 0, 1, 0 },
                { 1, 0, 1 },
                { 0, 1, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(1, 1, 1));

            CollectionAssert.AreEqual(expectedResult, arr);
        }

        [Test]
        public void Test2()
        {
            int[,] arr = new int[5, 5];
            int[,] expectedResult = new int[,]
            {
                { 0, 1, 0, 0, 0 },
                { 1, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(1, 1, 1));

            CollectionAssert.AreEqual(expectedResult, arr);
        }

        [Test]
        public void Test3()
        {
            int[,] arr = new int[5, 5];
            int[,] expectedResult = new int[,]
            {
                { 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(1, 3, 1));

            CollectionAssert.AreEqual(expectedResult, arr);
        }

        [Test]
        public void Test4()
        {
            int[,] arr = new int[5, 5];
            int[,] expectedResult = new int[,]
            {
                { 0, 0, 1, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(1, 3, 0));

            CollectionAssert.AreEqual(expectedResult, arr);
        }

        [Test]
        public void Test5()
        {
            int[,] arr = new int[5, 5];
            int[,] expectedResult = new int[,]
            {
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(1, 3, -1));

            CollectionAssert.AreEqual(expectedResult, arr);
        }

        [Test]
        public void Test6()
        {
            int[,] arr = new int[5, 5];
            int[,] expectedResult = new int[,]
            {
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(1, 4, 0));

            CollectionAssert.AreEqual(expectedResult, arr);
        }

        [Test]
        public void Test7()
        {
            int[,] arr = new int[5, 5];
            int[,] expectedResult = new int[,]
            {
                { 0, 1, 1, 1, 0 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 0, 1, 1, 1, 0 }
            };
            PerfectCircle.Draw(arr, new Circle(2, 2, 2));

            CollectionAssert.AreEqual(expectedResult, arr);
        }
    }
}