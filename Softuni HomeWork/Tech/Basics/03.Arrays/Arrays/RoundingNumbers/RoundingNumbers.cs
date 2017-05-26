using System;
using System.Linq;

namespace RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            int[] rounded = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                rounded[i] = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} -> {rounded[i]}");
            }
        }
    }
}