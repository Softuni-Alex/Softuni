using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class BombNumbers
    {
        public static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int number = input[0];
            int power = input[1];

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == number)
                {
                    int leftIndex = Math.Max(i - power, 0);
                    int rightIndex = Math.Min(i + power, sequence.Count - 1);

                    int lenght = rightIndex - leftIndex + 1;

                    sequence.RemoveRange(leftIndex, lenght);

                    i = 0;
                }
            }
            int sum = sequence.Sum();
            Console.WriteLine(sum);
        }
    }
}