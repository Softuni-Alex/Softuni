namespace Shapes.Shapes
{
    public class Rectangle : BasicShape
    {


        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateArea()
        {
            var S = this.Width* this.Height;
            return S;
        }

        public override double CalculatePerimeter()
        {
            var P = (2*this.Width) + (2*Height);
            return P;
        }
    }
}