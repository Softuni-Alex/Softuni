namespace HotelBookingSystem.Models
{
    using System;

    public class AvailableDate
    {
        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;

            this.ValidateDateRange();
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        private void ValidateDateRange()
        {
            if (this.EndDate < this.StartDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
        }
    }
}