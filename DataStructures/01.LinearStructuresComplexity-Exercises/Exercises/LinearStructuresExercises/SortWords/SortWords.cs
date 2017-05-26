using System;
using System.Collections.Generic;
using System.Linq;

namespace SortWords
{
    public class SortWords
    {
        public static void Main()
        {
            List<string> sentence = Console.ReadLine()
                .Split(' ')
                .ToList();

            sentence.Sort();

            Console.WriteLine(string.Join(" ", sentence));
        }
    }
}
