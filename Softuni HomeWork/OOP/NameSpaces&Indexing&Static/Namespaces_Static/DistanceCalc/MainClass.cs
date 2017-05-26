using System;
using Namespaces_Static;
namespace DistanceCalc
{
    class MainClass
    {
        static void Main()
        {

            Point3D point1 = new Point3D(234, 51, 99.9);
            Point3D point2 = new Point3D(42, -1235, -12.129);

            Console.WriteLine(point1);
            Console.WriteLine(point2);

            Console.WriteLine(DistanceCalculator.CalcDistance(point1,point2));

            Console.WriteLine(DistanceCalculator.CalcDistance(point1, Point3D.CoordinateStart));

        }
    }
}
