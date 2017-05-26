using System;
using System.Linq;

namespace SumReversedNumbers
{
    class SumReversedNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine()
                .Split()
                .Select(i => int.Parse(string.Join("", i.Reverse())))
                .Sum());
        }
    }
}