using System;
using System.Linq;

namespace ReversetheWordsInASentence
{
    class ReverseWordsSentence
    {
        static void Main()
        {
            char[] separators = ".,:;=()&[]\"\'\\ /!? ".ToCharArray();
            string input = Console.ReadLine();
            var word = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string aggghhh = "";
            for (int i = 0; i < word.Length; i++)
            {
                aggghhh += word[i];
            }
            char[] test = aggghhh.ToCharArray();
            var chars = input.Split(test, StringSplitOptions.RemoveEmptyEntries).ToList();

            Array.Reverse(word);

            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(word[i]);
                Console.Write(chars[i]);
            }
        }
    }
}