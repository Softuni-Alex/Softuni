using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            decimal[] nums = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            SortedDictionary<decimal, int> counts = new SortedDictionary<decimal, int>();

            foreach (var num in nums)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            foreach (var i in counts.Keys)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine("{0} -> {1}", i, counts[i]);
                }
            }
        }
    }
}