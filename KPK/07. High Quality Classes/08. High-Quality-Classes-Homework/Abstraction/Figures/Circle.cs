using System;

namespace Abstraction
{
    public class Circle : Figure
    {
        public Circle(double radius)
            : base(radius)
        {
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * Math.Pow(this.Radius, 2);
            return surface;
        }
    }
}
