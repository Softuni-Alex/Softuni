using System;
using System.Text;

namespace UnicodeCharacters
{
    class UnicodeChars
    {
        static void Main()
        {
            string input = Console.ReadLine();

            foreach (char character in input)
            {
                Console.Write("\\u{0:X4}", getUnicodeCode(character));
            }
            Console.WriteLine();
        }

        private static int getUnicodeCode(char character)
        {
            UTF32Encoding encoding = new UTF32Encoding();
            byte[] bytes = encoding.GetBytes(character.ToString().ToCharArray());

            return BitConverter.ToInt32(bytes, 0);
        }
    }
}