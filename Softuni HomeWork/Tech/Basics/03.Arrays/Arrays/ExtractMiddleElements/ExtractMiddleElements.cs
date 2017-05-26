using System;
using System.Linq;

namespace ExtractMiddleElements
{
    class ExtractMiddleElements
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", Extract(numbers)));
        }

        private static int[] Extract(int[] numbers)
        {
            int lenght = numbers.Length;

            if (lenght == 1)
            {
                return numbers;
            }
            if (lenght % 2 == 0)
            {
                return new int[]
                {
                    numbers[lenght/2-1],numbers[lenght/2]
                };
            }
            else
            {
                return new int[]
                {
                    numbers[lenght/2 - 1], numbers[lenght/2], numbers[lenght/2 + 1]
                };
            }
        }
    }
}