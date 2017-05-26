using System;

namespace NumbersInReversedOrder
{
    class NumbersInReversedOrder
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(Reverse(number));
        }

        static string Reverse(string number)
        {
            char[] next = number.ToCharArray();
            Array.Reverse(next);
            return new string(next);
        }
    }
}