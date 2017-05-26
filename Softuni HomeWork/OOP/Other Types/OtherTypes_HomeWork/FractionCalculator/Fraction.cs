using System;


using System.Runtime.InteropServices;

namespace FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }


        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be 0!");
                }
                this.denominator = value;
            }
        }




        public static Fraction operator +(Fraction firstFraction, Fraction secondFraction)
        {
            firstFraction.Numerator *= secondFraction.Denominator;
            secondFraction.Numerator *= firstFraction.Denominator;
            long commonDenominator = firstFraction.Denominator * secondFraction.Denominator;

            return new Fraction(firstFraction.Numerator + secondFraction.Numerator, commonDenominator);

        }

        public static Fraction operator -(Fraction firstFraction, Fraction secondFraction)
        {
            firstFraction.Numerator *= secondFraction.Denominator;
            secondFraction.Numerator *= firstFraction.Denominator;
            long commonDenominator = firstFraction.Denominator * secondFraction.Denominator;

            return new Fraction(firstFraction.Numerator - secondFraction.Numerator, commonDenominator);

        }
        public override string ToString()
        {
           return string.Format("{0}", (decimal)this.Numerator / this.Denominator);
        
        }
    }
}