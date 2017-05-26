using System;

namespace IntToHexAndBinary
{
    class IntToHexAndBinary
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string binary = Convert.ToString(num, 2);
            string hexa = Convert.ToString(num, 16);

            Console.WriteLine(hexa.ToUpper());
            Console.WriteLine(binary.ToUpper());
        }
    }
}