using System;

namespace Namespaces_Static
{
    public class Point3D
    {

        private static readonly Point3D coordinateStart = new Point3D(0, 0, 0);

        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Point3D CoordinateStart
        {
            get
            {
                return coordinateStart;
            }
        }

        public override string ToString()
        {
            return string.Format("Point 3D: X = {0}, Y = {1}, Z = {2}", this.x, this.y, this.z);
        }

    }
}
