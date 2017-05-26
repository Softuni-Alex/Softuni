using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniWaterSupplies
{
    class SoftUniWaterSupplies
    {
        static void Main()
        {
            int totalAmountOfWater = int.Parse(Console.ReadLine());
            decimal[] itemsInTheArray = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            int bottleCapacity = int.Parse(Console.ReadLine());

            int bottlesLeft = 0;
            List<int> indexesOfLeftBottles = new List<int>();

            decimal litersFilled = 0;
            if (totalAmountOfWater % 2 == 0)
            {
                for (int i = 0; i < itemsInTheArray.Length; i++)
                {
                    litersFilled += bottleCapacity - itemsInTheArray[i];
                    if (litersFilled > totalAmountOfWater)
                    {
                        bottlesLeft++;
                        indexesOfLeftBottles.Add(i);
                    }
                }
            }
            else
            {
                for (int i = itemsInTheArray.Length - 1; i >= 0; i--)
                {
                    litersFilled += bottleCapacity - itemsInTheArray[i];
                    if (litersFilled > totalAmountOfWater)
                    {
                        bottlesLeft++;
                        indexesOfLeftBottles.Add(i);
                    }
                }
            }
            if (litersFilled > totalAmountOfWater)
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottlesLeft}");
                Console.WriteLine($"With indexes: {string.Join(", ", indexesOfLeftBottles)}");
                Console.WriteLine($"We need {litersFilled - totalAmountOfWater} more liters!");
            }
            else
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalAmountOfWater - litersFilled}l.");
            }
        }
    }
}