using System;
using System.Globalization;

namespace Problem02
{
    class SoftuniCoffeeOrders
    {
        static void Main(string[] args)
        {
            long countOrders = long.Parse(Console.ReadLine());
            decimal totalSum = 0;

            for (int i = 0; i < countOrders; i++)
            {
                decimal capsulePrice = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsuleCount = long.Parse(Console.ReadLine());

                decimal calculations = capsulePrice * (capsuleCount * DateTime.DaysInMonth(orderDate.Year, orderDate.Month));
                totalSum += calculations;

                Console.WriteLine("The price for the coffee is: ${0:f2}", calculations);
            }
            Console.WriteLine("Total: ${0:f2}", totalSum);
        }
    }
}