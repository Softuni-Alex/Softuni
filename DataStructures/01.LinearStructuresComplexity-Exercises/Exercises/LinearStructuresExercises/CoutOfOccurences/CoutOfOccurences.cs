using System;
using System.Collections.Generic;
using System.Linq;

namespace CoutOfOccurences
{
    public class CoutOfOccurences
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Dictionary<int, int> output = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!output.ContainsKey(input[i]))
                {
                    output.Add(input[i], 0);
                }

                output[input[i]] += 1;
            }

            foreach (var print in output.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{print.Key} -> {print.Value} times");
            }
        }
    }
}
