using System;

namespace TriplesOfLetters
{
    class TriplesOfLetters
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char third = (char)('a' + k);
                        char second = (char)('a' + j);
                        char first = (char)('a' + i);
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}