using System;
using System.Text.RegularExpressions;

namespace RegexExercise
{
    public class MatchFullName
    {
        public static void Main()
        {
            string text = "Ivan IvanovA";
            string pattern = @"^I[a-z]+ I[a-z]+$";

            Regex regex = new Regex(pattern);

            Console.WriteLine(regex.IsMatch(text));
        }
    }
}