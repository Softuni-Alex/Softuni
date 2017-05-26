using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativeReverse
{
    class RemoveNegativeReverse
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = input.Where(x => x >= 0).Reverse().ToList();

            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}