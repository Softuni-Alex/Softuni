using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            int largestSequence = 1;
            int maxSequence = -1;
            int startIndex = 0;


            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == input[i - 1])
                {
                    largestSequence++;
                    if (largestSequence > maxSequence)
                    {
                        maxSequence = largestSequence;
                        startIndex = i - maxSequence + 1;
                    }
                }
                else
                {
                    largestSequence = 1;
                }
            }

            if (maxSequence < 0)
            {
                Console.WriteLine(input[0]);
            }

            for (int i = startIndex; i < maxSequence + startIndex; i++)
            {
                Console.Write(input[i] + " ");
            }
        }
    }
}