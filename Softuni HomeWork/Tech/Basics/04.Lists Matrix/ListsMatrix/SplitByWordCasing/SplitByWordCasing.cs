using System;
using System.Collections.Generic;

namespace SplitByWordCasing
{
    class SplitByWordCasing
    {
        static void Main(string[] args)
        {
            var separators = new char[]
            {
                ',', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', ' ','[',']'
            };
            var words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var lower = new List<string>();
            var upper = new List<string>();
            var mixed = new List<string>();

            foreach (var w in words)
            {
                var type = GetWordType(w);
                if (type == WordType.Uppercase)
                {
                    upper.Add(w);
                }
                else if (type == WordType.Lowercase)
                {
                    lower.Add(w);
                }
                else
                {
                    mixed.Add(w);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lower));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixed));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upper));

        }

        enum WordType
        {
            Uppercase,
            MixedCase,
            Lowercase
        };

        private static WordType GetWordType(string word)
        {
            var lowerLetters = 0;
            var upperLetters = 0;

            foreach (var l in word)
            {
                if (char.IsUpper(l))
                {
                    upperLetters++;
                }
                else if (char.IsLower(l))
                {
                    lowerLetters++;
                }
            }
            if (upperLetters == word.Length)
            {
                return WordType.Uppercase;
            }
            if (lowerLetters == word.Length)
            {
                return WordType.Lowercase;
            }
            else
            {
                return WordType.MixedCase;
            }
        }
    }
}