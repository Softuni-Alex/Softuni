using System.Text;

namespace _03.SoftuniNumerals
{
    using System;
    using System.Text.RegularExpressions;

    public class SoftuniNumerals
    {
        public static void Main()
        {
            Regex regex = new Regex(@"(aa)|(aba)|(bcc)|(cc)|(cdc)");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                do
                {
                    string s = match.Groups[1]
                } while (b);
            }
        }
    }
}