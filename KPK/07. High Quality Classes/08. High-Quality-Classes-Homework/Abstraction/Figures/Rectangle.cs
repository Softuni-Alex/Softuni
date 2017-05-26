namespace Abstraction
{
    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalcPerimeter()
        {
            double perimeter = this.Height * 2 + this.Width * 2;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Height * this.Width;
            return surface;
        }
    }
}
