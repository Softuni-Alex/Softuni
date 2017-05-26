using System;
using System.Linq;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;

            for (int currentElement = 0; currentElement < numbers.Length; currentElement++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                for (int i = currentElement + 1; i < numbers.Length; i++)
                {
                    sumRight += numbers[i];
                }
                for (int i = 0; i < currentElement; i++)
                {
                    sumLeft += numbers[i];
                }
                if (sumRight == sumLeft)
                {
                    Console.WriteLine(currentElement);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}