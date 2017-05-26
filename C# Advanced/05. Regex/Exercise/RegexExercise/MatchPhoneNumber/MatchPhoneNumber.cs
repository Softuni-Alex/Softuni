using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main()
        {
            string pattern = @"\+[\d]+(\s|\-)[\d]{1}\1[\d]{3}\1[\d]{4}";
            string text = "+359 2 222 2222, +359-2-222-2222";

            var regex = new Regex(pattern);

            Console.WriteLine(regex.Match(text));

        }
    }
}