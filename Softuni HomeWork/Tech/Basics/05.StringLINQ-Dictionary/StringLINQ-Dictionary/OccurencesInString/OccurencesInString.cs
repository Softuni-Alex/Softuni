using System;

namespace OccurencesInString
{
    class OccurencesInString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            var w = Console.ReadLine().ToLower();

            var startPos = 0;
            var count = 0;
            while (true)
            {
                var pos = text.IndexOf(w, startPos);
                if (pos == -1)
                {
                    break;
                }
                count++;
                startPos = pos + 1;
            }

            Console.WriteLine(count);
        }
    }
}
