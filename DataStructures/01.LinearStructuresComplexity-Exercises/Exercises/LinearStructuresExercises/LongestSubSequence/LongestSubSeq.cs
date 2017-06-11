using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int number = 0;
            int maxCount = 0;

            for (int i = 0; i < sequence.Count; i++)
            {
                int numberCount = 1;

                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        numberCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (numberCount > maxCount)
                {
                    number = sequence[i];
                    maxCount = numberCount;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
