using System;

namespace MockDateTime
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
