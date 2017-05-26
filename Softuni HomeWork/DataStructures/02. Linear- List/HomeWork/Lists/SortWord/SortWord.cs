using System;
using System.Collections.Generic;
using System.Linq;

namespace SortWord
{
    class SortWord
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> sequence = new List<string>();

            sequence = input.Split(' ').ToList();

            sequence.Sort();

            foreach (var seq in sequence)
            {
                Console.Write(seq + " ");
            }
        }
    }
}
