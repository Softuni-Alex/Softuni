using System;
using System.Linq;

namespace SieveOfEratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentPrime = 2;

            int[] numbers = Enumerable.Range(0, n + 1).ToArray();

            while (currentPrime < n)
            {
                for (int i = currentPrime * 2; i <= n; i += currentPrime)
                {
                    numbers[i] = 0;
                }

                currentPrime++;
                while (numbers[currentPrime] < 2 && currentPrime < n)
                {
                    currentPrime++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers.Where(number => number >= 2)));
        }
    }
}