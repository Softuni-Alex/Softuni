namespace SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(.)\1+");

            //Makes the multy letters in single ones
            Console.WriteLine(regex.Replace(input, "$1"));
        }
    }
}