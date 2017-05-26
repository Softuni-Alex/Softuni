using System;

namespace HexFormat
{
    class HexFormat
    {
        static void Main(string[] args)
        {
            string one = Console.ReadLine().Remove(0, 2);

            int value = Convert.ToInt32(one, 16);

            Console.WriteLine(value);
        }
    }
}