using System;
using System.Linq;

namespace SumArrays
{
    class SumArrays
    {
        static void Main(string[] args)
        {
            long[] first = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long[] second = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long result = Math.Max(first.Length, second.Length);
            long[] sumArr = new long[result];

            for (int i = 0; i < result; i++)
            {
                sumArr[i] = first[i % first.Length] + second[i % second.Length];
            }
            Console.WriteLine(string.Join(" ", sumArr));
        }
    }
}