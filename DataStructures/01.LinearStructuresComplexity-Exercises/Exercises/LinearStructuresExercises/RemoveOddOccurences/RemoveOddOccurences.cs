using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOccurences
{
    public class RemoveOddOccurences
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Dictionary<int, int> output = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!output.ContainsKey(numbers[i]))
                {
                    output.Add(numbers[i], 0);
                }

                output[numbers[i]] += 1;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (output[numbers[i]] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}