namespace SubString
{
    using System;

    public class Substring
    {
        public static void Main()
        {
            const char Search = 'р';

            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            bool hasMatch = false;
            int endIndex = jump;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == Search)
                {
                    hasMatch = true;

                    if (endIndex > text.Length)
                    {
                        endIndex = text.Length;
                    }

                    string matchedString = text.Substring(i, endIndex);
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }
            if (!hasMatch)
            {
                Console.WriteLine("no");
            }

        }
    }
}