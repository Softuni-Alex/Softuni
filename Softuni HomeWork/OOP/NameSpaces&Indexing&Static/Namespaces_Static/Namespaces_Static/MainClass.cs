using System;

namespace Namespaces_Static
{
    class MainClass
    {
        static void Main()
        {
            Point3D point = new Point3D(2.2, 3, 44.32);
            
            Point3D zero = Point3D.CoordinateStart;

            Console.WriteLine(point);

            Console.WriteLine();

            Console.WriteLine(zero);
        }

    }
}
