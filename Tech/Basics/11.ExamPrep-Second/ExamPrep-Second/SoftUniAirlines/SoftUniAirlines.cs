using System;

namespace SoftUniAirlines
{
    class SoftUniAirlines
    {
        static void Main(string[] args)
        {
            long numberOfFlights = long.Parse(Console.ReadLine());

            decimal overAllProfit = 0;
            decimal averageProfit = 0;
            for (int i = 0; i < numberOfFlights; i++)
            {
                long adultCount = long.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                long youthCount = long.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                long flightDuration = long.Parse(Console.ReadLine());

                decimal income = (adultCount * adultTicketPrice) + (youthCount * youthTicketPrice);
                overAllProfit += income;
                decimal expense = flightDuration * fuelConsumptionPerHour * fuelPricePerHour;
                overAllProfit -= expense;

                if (income > expense)
                {
                    Console.WriteLine("You are ahead with {0:f3}$.", income - expense);
                }
                if (expense > income)
                {
                    Console.WriteLine("We've got to sell more tickets! We've lost {0:f3}$.", income - expense);
                }
            }
            Console.WriteLine("Overall profit -> {0:f3}$.", overAllProfit);
            Console.WriteLine("Average profit -> {0:f3}$.", overAllProfit / numberOfFlights);
        }
    }
}