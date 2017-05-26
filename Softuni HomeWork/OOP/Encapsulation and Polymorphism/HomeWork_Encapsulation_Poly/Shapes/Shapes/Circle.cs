using System;
using Shapes.Interfaces;

namespace Shapes.Shapes
{
    public class Circle : IShape
    {
        private int r;

        public Circle(int r)
        {
            this.R = r;
        }

        public int R
        {
            get { return this.r; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Radius cannot be a negative number!");
                    }
                    this.r = value;

                }
                catch (FormatException)
                {

                    throw new FormatException("Please enter a number!");
                }

            }
        }

        public double CalculateArea()
        {
            var S = Math.PI * Math.Pow(this.R, 2);
            return S;
        }

        public double CalculatePerimeter()
        {
            var P = Math.PI * 2 * this.R;
            return P;
        }
    }
}