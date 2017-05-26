using System;
using System.Linq;

namespace Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3)));
        }
    }
}