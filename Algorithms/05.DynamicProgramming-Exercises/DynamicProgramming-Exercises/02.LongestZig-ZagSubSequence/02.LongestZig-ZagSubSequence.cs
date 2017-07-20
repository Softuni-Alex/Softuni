using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.LongestZig_ZagSubSequence
{
    public class LongestZigZagSubsequence
    {
        private static int maxLength = 0;

        private static int lastIndex = -1;

        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] result = FindLongestZigZagSubsequence(numbers);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] FindLongestZigZagSubsequence(int[] numbers)
        {
            int[] lengthEven = new int[numbers.Length];
            int[] backtrackEven = new int[numbers.Length];
            int[] lengthOdd = new int[numbers.Length];
            int[] backtrackOdd = new int[numbers.Length];
            bool oddIsSmaller = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                lengthEven[i] = 1;
                backtrackEven[i] = -1;
                lengthOdd[i] = 1;
                backtrackOdd[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (lengthEven[j] + 1 > lengthEven[i])
                    {
                        if ((lengthEven[j] % 2 == 0 && numbers[i] < numbers[j]) ||
                            (lengthEven[j] % 2 == 1 && numbers[i] > numbers[j]))
                        {
                            lengthEven[i] = lengthEven[j] + 1;
                            backtrackEven[i] = j;
                        }
                    }
                    if (lengthOdd[j] + 1 > lengthOdd[i])
                    {
                        if ((lengthOdd[j] % 2 == 0 && numbers[i] > numbers[j]) ||
                            (lengthOdd[j] % 2 == 1 && numbers[i] < numbers[j]))
                        {
                            lengthOdd[i] = lengthOdd[j] + 1;
                            backtrackOdd[i] = j;
                        }
                    }
                }
                if (lengthEven[i] > maxLength)
                {
                    oddIsSmaller = false;
                    maxLength = lengthEven[i];
                    lastIndex = i;
                }
                if (lengthOdd[i] > maxLength)
                {
                    oddIsSmaller = true;
                    maxLength = lengthOdd[i];
                    lastIndex = i;
                }
            }
            var list = new List<int>();
            ReconstructSequence(list, oddIsSmaller ? backtrackOdd : backtrackEven, numbers);

            list.Reverse();
            return list.ToArray();
        }

        private static void ReconstructSequence(List<int> list, int[] backtrack, int[] numbers)
        {
            while (lastIndex != -1)
            {
                list.Add(numbers[lastIndex]);
                lastIndex = backtrack[lastIndex];
            }
        }
    }
}