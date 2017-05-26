using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> seqFound = new List<int>();

            int initial = sequence[0];
            for (int i = 1; i < sequence.Count; i++)
            {
                if (initial == sequence[i])
                {
                    seqFound.Add(initial);
                }
                if (sequence[i] == sequence[i + 1])
                {

                }
            }

            Console.WriteLine(string.Join(" ", seqFound));
        }
    }
}
