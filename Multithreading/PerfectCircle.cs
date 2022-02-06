using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal static class PerfectCircle
    {
        public static void Draw(int[,] arr, Circle circle)
        {
            // Parameters:
            //   arr:
            //     the array in which the circle will be drawn.
            //
            //   circle:
            //     the circle that will be drawn in the array

            Canvas canvas = new Canvas(arr);
            canvas.SetCenter(circle.a, circle.b);

            int x = 0, y = circle.radius;
            double delta1, delta2;
            while (x <= circle.radius && y >= 0)
            {
                canvas.SetPoint(x, y, 1);
                canvas.DrawSymmetricPoints(x, y, 1);

                // choose the next point according to the distance from the center of the circle.
                // the closer the distance to circle.radius, the better this point fits to the circle edge.
                delta1 = Math.Abs(Math.Pow(circle.radius, 2) - canvas.DistanceFromOrigin(x + 1, y - 1));
                delta2 = Math.Abs(Math.Pow(circle.radius, 2) - canvas.DistanceFromOrigin(x + 1, y));
                x += 1;
                y = (delta1 <= delta2) ? y - 1 : y;

                // since x advances one step in each iteration, the while loop is guranteed to terminate.
                // we expect that when it happens, `y` value would be 0.
            }
            Console.WriteLine("x = {0}, y = {1}", x, y);
        }        
    }

    internal class Circle
    {
        public Circle(ushort radius, int a, int b)
        {
            this.radius = radius;
            this.a = a;
            this.b = b;
        }

        public readonly ushort radius;
        public readonly int a;
        public readonly int b;
    }

    internal class Canvas
    {
        private int[,] canvas;
        int centerRow, centerColumn;

        public Canvas(int width, int height)
        {
            canvas = new int[height, width];
            centerRow = centerColumn = 0;
        }

        public Canvas(int[,] canvas)
        {
            this.canvas = canvas;
            centerRow = centerColumn = 0;
        }

        public void SetCenter(int x, int y)
        {
            centerColumn = x;
            centerRow = y;
        }

        public void SetPoint(int x, int y, int value)
        {
            int col = centerColumn - x;
            int row = centerRow + y;

            if (col < 0 || col >= canvas.GetLength(1) || row < 0 || row >= canvas.GetLength(0))
            {
                return;
            }

            canvas[row, col] = value;
        }

        public int GetPoint(int x, int y)
        {
            int col = centerColumn - x;
            int row = centerRow + y;

            if (col < 0 || col >= canvas.GetLength(1) || row < 0 || row >= canvas.GetLength(0))
            {
                throw new IndexOutOfRangeException();
            }

            return canvas[row, col];
        }

        public double DistanceFromOrigin(int x, int y)
        {
            int col = centerColumn - x;
            int row = centerRow - y;
            return Math.Pow(row - centerRow, 2) + Math.Pow(col - centerColumn, 2);
        }

        public void DrawSymmetricPoints(int x, int y, int value)
        {
            if (x == 0 && y > 0)
            {
                this.SetPoint(y, x, value);
                this.SetPoint(x, -y, value);
                this.SetPoint(-y, x, value);
            }
            else
            {
                this.SetPoint(-x, y, value);
                this.SetPoint(-x, -y, value);
                this.SetPoint(x, -y, value);
            }
        }
    }
}
