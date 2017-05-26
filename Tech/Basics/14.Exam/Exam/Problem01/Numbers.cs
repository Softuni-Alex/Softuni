using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<long> averageNumbers = Console.ReadLine().Split().Select(long.Parse).ToList();

            decimal sum = averageNumbers.Sum();
            decimal average = sum / averageNumbers.Count;

            List<long> result = averageNumbers.Where(x => x > average).OrderBy(x => -x).Take(5).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No");
            }

            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}