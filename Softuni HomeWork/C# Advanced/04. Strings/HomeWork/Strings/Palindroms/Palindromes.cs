using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindroms
{
    class Palindromes
    {
        static void Main()
        {
            string input = Console.ReadLine();

            SortedSet<string> inputWords = new SortedSet<string>(input.Split(" ,.?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

            // Get every entry of InputWords where the entry is equal to its reverse.
            IEnumerable<string> palindromes = inputWords.Where(w => w.SequenceEqual(w.Reverse()));

            Console.WriteLine(string.Join(", ", palindromes));
        }
    }
}
