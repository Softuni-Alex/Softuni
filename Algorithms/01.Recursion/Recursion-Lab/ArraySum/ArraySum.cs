using System;
using System.Linq;

namespace ArraySum
{
    public class ArraySum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(numbers, 0));
        }

        private static int Sum(int[] numbers, int index)
        {
            if (index >= numbers.Length - 1)
            {
                return numbers[index];
            }

            var element = numbers[index];

            return element + Sum(numbers, index + 1);
        }
    }
}
