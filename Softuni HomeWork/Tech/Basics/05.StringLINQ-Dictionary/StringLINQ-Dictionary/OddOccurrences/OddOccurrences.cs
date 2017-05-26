using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var words = text.Split();
            var counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts[word] = 1;
                }
            }

            var list = new List<string>();

            foreach (var count in counts)
            {
                if (count.Value % 2 == 1)
                {
                    list.Add(count.Key);
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}