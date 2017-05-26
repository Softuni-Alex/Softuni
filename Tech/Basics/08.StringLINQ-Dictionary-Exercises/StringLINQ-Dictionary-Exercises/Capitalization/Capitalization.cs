using System;
using System.Text;

namespace Capitalization
{
    class Capitalization
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Console.WriteLine(CapitalizeWords(words));
        }

        public static string CapitalizeWords(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            // Upper the first char.
            sb.Append(char.ToUpper(value[0]));
            for (int i = 1; i < value.Length; i++)
            {
                // Get the current char.
                char c = value[i];

                // Upper if after a space.
                if (char.IsWhiteSpace(value[i - 1]) || char.IsPunctuation(value[i - 1]))
                {
                    c = char.ToUpper(c);
                }
                else
                {
                    c = char.ToLower(c);
                }
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}