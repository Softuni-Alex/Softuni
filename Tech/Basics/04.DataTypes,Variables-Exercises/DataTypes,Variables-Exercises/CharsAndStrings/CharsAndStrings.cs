using System;

namespace CharsAndStrings
{
    class CharsAndStrings
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            char d = char.Parse(Console.ReadLine());
            string last = Console.ReadLine();

            Console.WriteLine(name);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(last);
        }
    }
}