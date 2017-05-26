using System;

namespace ReverseChars
{
    class ReverseChars
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            Console.WriteLine(Char.ToString(third) + Char.ToString(second) + Char.ToString(first));
        }
    }
}