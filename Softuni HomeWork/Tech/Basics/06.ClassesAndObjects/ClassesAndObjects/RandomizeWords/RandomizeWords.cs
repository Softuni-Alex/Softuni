using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            Random random = new Random();

            for (int first = 0; first < input.Count; first++)
            {
                var second = random.Next(0, input.Count);
                var old = input[first];
                input[first] = input[second];
                input[second] = old;
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}