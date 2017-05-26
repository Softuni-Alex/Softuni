using System;

namespace PrintPartOfASCIITable
{
    class PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int lastIndex = int.Parse(Console.ReadLine());

            string result = String.Empty;

            for (int i = startIndex; i <= lastIndex; i++)
            {
                result += (char)i + " ";
            }
            Console.WriteLine(result);
        }
    }
}