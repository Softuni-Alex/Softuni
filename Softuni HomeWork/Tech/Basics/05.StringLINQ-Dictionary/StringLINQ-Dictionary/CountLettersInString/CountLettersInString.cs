using System;
using System.Linq;

namespace CountLettersInString
{
    class CountLettersInString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int[] counts = new int[input.Max() + 1];

            foreach (var ch in input)
            {
                counts[ch]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine($"{(char)i} -> {counts[i]}");
                }
            }
        }
    }
}
