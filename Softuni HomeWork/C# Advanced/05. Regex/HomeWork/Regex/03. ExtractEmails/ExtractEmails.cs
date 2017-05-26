using System.Text.RegularExpressions;

namespace _03.ExtractEmails
{
    using System;
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"[a-z]+[\.][a-z]+@[a-z]+[\.][a-z.]+";

            Regex regex = new Regex(pattern);

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match + " ");
            }
        }
    }
}