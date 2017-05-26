using System;

namespace SweetDessert
{
    class SweetDessert
    {
        static void Main(string[] args)
        {
            decimal ivanchoCash = decimal.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal singleBanana = decimal.Parse(Console.ReadLine());
            decimal singleEgg = decimal.Parse(Console.ReadLine());
            decimal kiloBerries = decimal.Parse(Console.ReadLine());

            decimal portions = Math.Ceiling(numberOfGuests / 6.00m);

            decimal sumProducts = (2 * (singleBanana * portions)) + (4 * (singleEgg * portions)) + (0.2m * (kiloBerries * portions));

            if (sumProducts <= ivanchoCash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:f2}lv.", sumProducts);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:f2}lv more.", sumProducts - ivanchoCash);
            }
        }
    }
}