using System;
using System.Linq;

namespace ClosestTwoPoints
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

        public static Point[] FindClosestPoints(Point[] points)
        {
            var minDistance = double.MaxValue;

            Point[] closestTwoPoints = null;

            for (int firstPoint = 0; firstPoint < points.Length; firstPoint++)
            {
                for (int secondPoint = firstPoint + 1; secondPoint < points.Length; secondPoint++)
                {
                    double distance = CalculateDistance(points[firstPoint], points[secondPoint]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTwoPoints = new Point[] { points[firstPoint], points[secondPoint] };
                    }
                }
            }
            return closestTwoPoints;
        }

        public static double CalculateDistance(Point first, Point second)
        {
            var deltaX = second.X - first.X;
            var deltaY = second.Y - first.Y;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }

        public static Point[] ReadPoints()
        {
            var n = int.Parse(Console.ReadLine());
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = ReadPoint();
            }
            return points;
        }

        private static Point ReadPoint()
        {
            double[] pairs = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Point point = new Point(pairs[0], pairs[1]);
            return point;
        }

        public static void PrintPoint(Point point)
        {
            Console.WriteLine("({0}, {1})", point.X, point.Y);
        }
    }

    public class ClosestTwoPoints
    {
        public static void Main(string[] args)
        {
            Point[] points = Point.ReadPoints();
            var closesPoints = Point.FindClosestPoints(points);

            Console.WriteLine("{0:f3}", Point.CalculateDistance(closesPoints[0], closesPoints[1]));

            Point.PrintPoint(closesPoints[0]);
            Point.PrintPoint(closesPoints[1]);
        }
    }
}