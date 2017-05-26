namespace Abstraction
{
    using Abstraction.Interfaces;
    using System;
    public abstract class Figure : IFigure
    {

        private double radius;

        protected Figure(double radius)
        {
            this.Radius = radius;
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Radius
        {
            get { return this.radius; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "Radius cannot be negative!");
                }
                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();
        public abstract double CalcSurface();

    }
}
