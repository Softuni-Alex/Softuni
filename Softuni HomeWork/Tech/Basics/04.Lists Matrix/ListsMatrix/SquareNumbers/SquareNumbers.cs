using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareNumbers
{
    class SquareNumbers
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resouce = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (Math.Sqrt(input[i]) == (int)Math.Sqrt(input[i]))
                {
                    resouce.Add(input[i]);
                }
            }

            resouce.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine(string.Join(" ", resouce));
        }
    }
}