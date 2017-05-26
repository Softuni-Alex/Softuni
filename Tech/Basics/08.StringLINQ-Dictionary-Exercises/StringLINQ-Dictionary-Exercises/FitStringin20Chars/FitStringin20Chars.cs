using System;

namespace FitStringin20Chars
{
    class FitStringin20Chars
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length < 20)
            {
                input = input.PadRight(20, '*');
            }
            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
            }
            Console.WriteLine(input);
        }
    }
}