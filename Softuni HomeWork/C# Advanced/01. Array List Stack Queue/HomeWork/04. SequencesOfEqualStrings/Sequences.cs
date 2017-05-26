using System;
using System.Collections.Generic;

namespace _04.SequencesOfEqualStrings
{
    class Sequences
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<string> buffer = new List<string>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i].ToLower().CompareTo(input[i + 1].ToLower()) == 0)
                {
                    buffer.Add(input[i]);
                }
                else
                {
                    buffer.Add(input[i]);
                    Console.WriteLine(String.Join(" ", buffer));
                    buffer.Clear();
                }
            }
            //Last buffer;
            buffer.Add(input[input.Length - 1]);
            Console.WriteLine(String.Join(" ", buffer));
        }
    }
}
