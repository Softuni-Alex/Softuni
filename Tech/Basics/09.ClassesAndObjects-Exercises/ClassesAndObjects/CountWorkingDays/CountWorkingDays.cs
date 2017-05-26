using System;
using System.Collections.Generic;

namespace CountWorkingDays
{
    class CountWorkingDays
    {
        static void Main(string[] args)
        {
            string[] startDate = Console.ReadLine().Split('-');
            string[] endDate = Console.ReadLine().Split('-');

            DateTime start = new DateTime(int.Parse(startDate[2]), int.Parse(startDate[1]), int.Parse(startDate[0]));
            DateTime end = new DateTime(int.Parse(endDate[2]), int.Parse(endDate[1]), int.Parse(endDate[0]));

            int startYear = int.Parse(startDate[2]);
            int endYear = int.Parse(endDate[2]);

            List<DateTime> listHolidays = new List<DateTime>();

            for (int i = startYear; i <= endYear; i++)
            {
                listHolidays.Add(new DateTime(i, 1, 1));
                listHolidays.Add(new DateTime(i, 3, 3));
                listHolidays.Add(new DateTime(i, 5, 1));
                listHolidays.Add(new DateTime(i, 5, 6));
                listHolidays.Add(new DateTime(i, 5, 24));
                listHolidays.Add(new DateTime(i, 9, 6));
                listHolidays.Add(new DateTime(i, 9, 22));
                listHolidays.Add(new DateTime(i, 11, 1));
                listHolidays.Add(new DateTime(i, 12, 24));
                listHolidays.Add(new DateTime(i, 12, 25));
                listHolidays.Add(new DateTime(i, 12, 26));
            }

            Console.WriteLine(GetWorkingDays(start, end, listHolidays));
        }

        public static int GetWorkingDays(DateTime from, DateTime to, List<DateTime> holidays)
        {
            int totalDays = 0;

            for (var i = from; i <= to; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday && !holidays.Contains(i))
                {
                    totalDays++;
                }
            }
            return totalDays;
        }
    }
}