using System;
using System.Linq;

namespace DistanceBetweenPoints
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public static double CalculateDistance(Point first, Point second)
        {
            var deltaX = second.X - first.X;
            var deltaY = second.Y - first.Y;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }

    public class DistanceBetweenPoints
    {
        static void Main(string[] args)
        {
            double[] tokkenFirst = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] tokkenSecond = Console.ReadLine().Split().Select(double.Parse).ToArray();

            double x1 = tokkenFirst[0];
            double y1 = tokkenFirst[1];

            double x2 = tokkenSecond[0];
            double y2 = tokkenSecond[1];

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);

            Console.WriteLine("{0:f3}", Point.CalculateDistance(point1, point2));
        }
    }
}