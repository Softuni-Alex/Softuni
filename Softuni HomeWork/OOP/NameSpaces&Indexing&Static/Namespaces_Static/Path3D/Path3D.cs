using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistanceCalc;
using Namespaces_Static;

namespace Path3D
{
    class Path3DS
    {
        static void Main(string[] args)
        {

            Point3D p1 = new Point3D(45, -5, 23);
            Point3D p2 = new Point3D(-25, 78, 115);
            Point3D p3 = new Point3D(2, 56, -8);

            List<Point3D> points1 = new List<Point3D> { p1, p2, p3 };
            List<Point3D> points2 = new List<Point3D> { p2, p3 };
            List<Point3D> points3 = new List<Point3D> { p1, p3 };

            Path3D path1 = new Path3D(points1);
            Path3D path2 = new Path3D(points2);
            Path3D path3 = new Path3D(points3);

            Storage.SavePath("../../path3D.txt", path1, path2, path3);
            Path3D newPath = Storage.LoadPath("../../path3D");
            Storage.SavePath("../../path3D.txt", newPath);

            Console.WriteLine(newPath);
        }
    }
}
