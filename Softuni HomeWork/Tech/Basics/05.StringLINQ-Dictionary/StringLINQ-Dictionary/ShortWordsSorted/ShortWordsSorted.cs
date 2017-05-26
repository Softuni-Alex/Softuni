using System;
using System.Linq;

namespace ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().ToLower()
                .Split(new char[] { '.', ',', ':', '(', ')', '[', ']', '\"', '\'', '/', '\\', '!', '?', ' ' })
                .Where(w => w != "")
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .Distinct()));
        }
    }
}