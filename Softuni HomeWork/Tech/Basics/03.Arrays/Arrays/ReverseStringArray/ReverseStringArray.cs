using System;
using System.Linq;

namespace ReverseStringArray
{
    class ReverseStringArray
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            var reversed = input.Reverse();

            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}