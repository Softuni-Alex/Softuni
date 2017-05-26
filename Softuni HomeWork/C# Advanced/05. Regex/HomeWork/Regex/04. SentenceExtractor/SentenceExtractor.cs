using System;
using System.Text.RegularExpressions;

namespace _04.SentenceExtractor
{
    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();

            MatchCollection matches = IsSentence(text);

            foreach (Match sentence in matches)
            {
                string x = sentence.ToString();
                if (IsWordInSentence(x, keyword))
                {
                    // printing
                    Console.WriteLine(x.Trim());
                }
            }
        }

        private static bool IsWordInSentence(string sentence, string word)
        {
            return Regex.Matches(sentence, string.Format(@"\b{0}\b", word), RegexOptions.IgnoreCase).Count != 0;
        }

        private static MatchCollection IsSentence(string text)
        {
            string pattern = @"([^.!?]+(?=[.!?])[.!?])";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(text);
            return matches;
        }
    }
}