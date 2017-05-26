using System;

namespace ForbiddenSubstrings
{
    class ForbiddenSubstrings
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var words = Console.ReadLine().Split();

            foreach (var word in words)
            {
                var stars = new string('*', word.Length);
                text = text.Replace(word, stars);
            }
            Console.WriteLine(text);
        }
    }
}