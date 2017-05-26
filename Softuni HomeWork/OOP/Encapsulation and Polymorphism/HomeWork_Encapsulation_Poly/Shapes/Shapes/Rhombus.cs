namespace Shapes.Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double width, double height, int visochina)
        {
            this.Width = width;
            this.Height = height;
            this.Visochina = visochina;
        }

        public int Visochina { get; set; }


        public override double CalculateArea()
        {

            var S = Width * Visochina;
            return S;

        }
        public override double CalculatePerimeter()
        {

            var P = 4 * this.Width;
            return P;
        }
    }
}