using System;
using System.Linq;

namespace CirclesIntersection
{
    public class Circle
    {
        public double Radius { get; set; }
        public Point Center { get; set; }

        public double DistanceBetweenCircleCenters(Point first, Point second)
        {
            var deltaX = second.X - first.X;
            var deltaY = second.Y - first.Y;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class CirclesIntersection
    {
        public static void Main(string[] args)
        {
            double[] firstCircle = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] secondCircle = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Point centerA = new Point()
            {
                X = firstCircle[0],
                Y = firstCircle[1]
            };

            Point centerB = new Point()
            {
                X = secondCircle[0],
                Y = secondCircle[1]
            };

            Circle circleA = new Circle()
            {
                Center = centerA,
                Radius = firstCircle[2]
            };

            Circle circleB = new Circle()
            {
                Center = centerB,
                Radius = secondCircle[2]
            };

            if (Intersect(circleA, circleB))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static bool Intersect(Circle first, Circle second)
        {
            double distance = CalculateDistance(first.Center, second.Center);
            double sumOfRadiuses = first.Radius + second.Radius;
            if (distance > sumOfRadiuses)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static double CalculateDistance(Point a, Point b)
        {
            var deltaX = b.X - a.X;
            var deltaY = b.Y - a.Y;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}