namespace InterestCalculator
{
    using System;


    public delegate decimal CalculateInterest(decimal money, decimal interest, int years);

    class InterestCalculator
    {
        public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest calculationMethod)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.calculation = calculationMethod;
        }

        private readonly CalculateInterest calculation;
        private decimal interest;
        private int years;

        public decimal Money { get; set; }

        public decimal Interest
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("interest", "The interest cannot be negative");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get
            {
                return this.years;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("years", "The number of years cannot be negative.");
                }

                this.years = value;
            }
        }


        public decimal Balance
        {
            get
            {
                return this.calculation(this.Money, this.Interest, this.Years);
            }
        }

    }
}
