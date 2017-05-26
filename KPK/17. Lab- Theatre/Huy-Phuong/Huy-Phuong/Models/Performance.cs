namespace Huy_Phuong.Models
{
    using Interfaces;
    using System;
    using System.Text;

    public class Performance : IPerformance
    {
        public Performance(ITheatre theatre, string performanceName, DateTime date, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.PerformanceName = performanceName;
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public DateTime Date { get; private set; }

        public TimeSpan Duration { get; private set; }

        public ITheatre Theatre { get; private set; }

        public string PerformanceName { get; private set; }

        public decimal Price { get; private set; }

        public override string ToString()
        {
            StringBuilder performanceAsString = new StringBuilder();
            performanceAsString.AppendFormat("Performance(Theatre: {0}; ", this.Theatre);
            performanceAsString.AppendFormat("Performance Name: {0}; ", this.PerformanceName);
            performanceAsString.AppendFormat("Date: {0}, ", this.Date.ToString("dd.MM.yyyy HH:mm"));
            performanceAsString.AppendFormat("Duration: {0}, ", this.Duration.ToString("hh':'mm"));
            performanceAsString.AppendFormat("Price: {0})", this.Price.ToString("f2"));

            return performanceAsString.ToString();
        }

        public int CompareTo(Object performance)
        {
            var otherPerformance = performance as IPerformance;
            if (otherPerformance == null)
            {
                throw new InvalidCastException("The object does not implement type Performance");
            }
            int result = this.Date.CompareTo(otherPerformance.Date);
            return result;
        }
    }
}

