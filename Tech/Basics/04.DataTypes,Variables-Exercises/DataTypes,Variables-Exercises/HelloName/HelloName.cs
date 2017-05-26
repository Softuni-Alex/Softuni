using System;

namespace HelloName
{
    class HelloName
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Console.WriteLine(Name(name));
        }

        static string Name(string name)
        {
            string result = "Hello, " + name + "!";
            return result;
        }
    }
}