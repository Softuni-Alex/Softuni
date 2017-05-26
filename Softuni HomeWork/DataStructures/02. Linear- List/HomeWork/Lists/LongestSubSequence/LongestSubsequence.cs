using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubSequence
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            var line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                numbers = line.Split().Select(int.Parse).ToList();
            }
            else
            {
                throw new NullReferenceException("Collection can not be null or empty!");
            }

            var subSequence = FindLongestSubsequence(numbers);
            Console.WriteLine(string.Join(" ", subSequence));
        }

        public static List<int> FindLongestSubsequence(List<int> source)
        {
            var result = new List<int>();
            for (int i = 0; i < source.Count; i++)
            {
                var test = source.Skip(i).TakeWhile(s => s == source[i]).ToList();
                if (test.Count > result.Count)
                {
                    result = test;
                }
            }
            return result.Count != 0 ? result : new List<int>() { source[0] };
        }
    }
}
}
