using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Namespaces_Static;

namespace DistanceCalc
{
    public static class DistanceCalculator
    {
        public static double CalcDistance(Point3D ex1,Point3D ex2)
        {
            double xDiff = Math.Pow((ex1.X - ex2.X), 2);
            double yDiff = Math.Pow((ex1.Y - ex2.Y), 2);
            double zDiff = Math.Pow((ex1.Z - ex2.Z), 2);

            return Math.Sqrt(xDiff + yDiff + zDiff);
        }
    }
}
 