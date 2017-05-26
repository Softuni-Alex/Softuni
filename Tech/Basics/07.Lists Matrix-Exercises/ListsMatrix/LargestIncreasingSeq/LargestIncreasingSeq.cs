using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestIncreasingSeq
{
    class LargestIncreasingSeq
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", FindLongestIncreasingSubsequence(sequence)));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            var length = new int[sequence.Length];
            var prev = new int[sequence.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                length[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && length[j] + 1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        prev[i] = j;
                    }
                }
                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    lastIndex = i;
                }
            }
            var list = new List<int>();
            while (lastIndex != -1)
            {
                list.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            list.Reverse();
            return list.ToArray();
        }
    }
}
