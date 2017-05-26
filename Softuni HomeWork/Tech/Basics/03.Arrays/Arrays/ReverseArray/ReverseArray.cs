using System;

namespace ReverseArray
{
    class ReverseArray
    {
        static void Main(string[] args)
        {
            int numberToEnter = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberToEnter];

            for (int i = 0; i < numberToEnter; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}