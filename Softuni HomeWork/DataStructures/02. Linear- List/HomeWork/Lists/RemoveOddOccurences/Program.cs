using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOccurences
{
    public static class Program
    {
        private static List<int> numbers;
        private static List<string> words;

        public static void RemoveOddOccurences<T>(this List<T> source)
        {
            var dictionaryNumbers = source.GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
            foreach (var number in dictionaryNumbers)
            {
                if (number.Value % 2 != 0)
                {
                    source.RemoveAll(s => s.Equals(number.Key));
                }
            }
        }

        public static void Main()
        {
            var line = Console.ReadLine();
            words = Console.ReadLine().Split().ToList();
            try
            {
                numbers = line.Split().Select(int.Parse).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Source);
            }
            words.RemoveOddOccurences();
            numbers.RemoveOddOccurences();

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(string.Join(" ", words));
        }
    }
}