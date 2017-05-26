using System;

namespace StringObjects
{
    class StringObjects
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = " World";

            object concat = hello + world;

            string result = (string)concat;

            Console.WriteLine(result);
        }
    }
}