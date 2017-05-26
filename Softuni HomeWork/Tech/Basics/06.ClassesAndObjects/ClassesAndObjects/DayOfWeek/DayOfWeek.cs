using System;
using System.Globalization;

namespace DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            string inputDateTime = Console.ReadLine();

            var result = DateTime.ParseExact(inputDateTime, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(result.DayOfWeek);
        }
    }
}