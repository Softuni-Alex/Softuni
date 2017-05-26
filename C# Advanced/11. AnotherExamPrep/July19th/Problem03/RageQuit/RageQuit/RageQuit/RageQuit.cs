using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(\D+)(\d+)");

            Match matches = regex.Match(input);

            StringBuilder result = new StringBuilder();

            do
            {
                string pair = matches.Groups[1].Value.ToUpper();
                int count = int.Parse(matches.Groups[2].Value);

                for (int i = 0; i < count; i++)
                {
                    result.Append(pair);
                }
                matches = matches.NextMatch();
            } while (matches.Success);

            int uniques = result.ToString().Distinct().Count();

            Console.WriteLine("Unique symbols used: {0}", uniques);
            Console.WriteLine(result);
        }
    }
}