using System;
using System.Text;

namespace StringFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder text = new StringBuilder();

            text.Append(Console.ReadLine());

            foreach (var bannedWord in bannedWords)
            {
                text.Replace(bannedWord, new string('*', bannedWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}
