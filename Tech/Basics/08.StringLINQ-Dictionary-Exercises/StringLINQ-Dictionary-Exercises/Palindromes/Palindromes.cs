using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', '.', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (IsPalindrome(input[i]))
                {
                    result.Add(input[i]);
                }
            }

            Console.WriteLine(string.Join(", ", result.Distinct().OrderBy(x => x)));
        }

        public static bool IsPalindrome(string input)
        {
            return input.SequenceEqual(input.Reverse());
        }
    }
}