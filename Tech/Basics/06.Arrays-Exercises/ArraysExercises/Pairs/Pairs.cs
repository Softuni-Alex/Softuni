using System;
using System.Linq;

namespace Pairs
{
    class Pairs
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int pesh = Math.Abs(numbers[i] - numbers[j]); // raboti i sus otricatelni
                    if (pesh == difference)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
// int pesh = numbers[i] - numbers[j]; - raboti ako nqma otricatelni