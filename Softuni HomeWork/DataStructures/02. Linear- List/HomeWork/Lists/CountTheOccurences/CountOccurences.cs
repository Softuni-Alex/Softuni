using System;
using System.Collections.Generic;
using System.Linq;

namespace CountTheOccurences
{
    public class Program
    {

        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            int[] numbers;

            try
            {
                numbers = line.Split().Select(int.Parse).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            PrintDictionary(CountOccurences(numbers));
        }

        public static SortedDictionary<int, int> CountOccurences(int[] numbers)
        {
            SortedDictionary<int, int> result = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (result.ContainsKey(numbers[i]))
                {
                    result[numbers[i]]++;
                }
                else
                {
                    result[numbers[i]] = 1;
                }
            }
            return result;
        }

        private static void PrintDictionary(SortedDictionary<int, int> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine("{0} --> {1} time(s)", item.Key, item.Value);
            }
        }
    }
}