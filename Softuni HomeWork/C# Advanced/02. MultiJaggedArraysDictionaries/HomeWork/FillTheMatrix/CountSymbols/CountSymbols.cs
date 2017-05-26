using System.Linq;

namespace CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!symbols.ContainsKey(text[i]))
                {
                    symbols.Add(text[i], text.Count(x => x == text[i]));
                }
            }

            foreach (var element in symbols)
            {
                Console.WriteLine("{0}: {1} time/s", element.Key, element.Value);
            }
        }
    }
}