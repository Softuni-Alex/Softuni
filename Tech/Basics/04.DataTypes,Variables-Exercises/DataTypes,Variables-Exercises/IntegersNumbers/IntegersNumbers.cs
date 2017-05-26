using System;

namespace IntegersNumbers
{
    class IntegersNumbers
    {
        static void Main(string[] args)
        {
            short one = short.Parse(Console.ReadLine());
            byte two = byte.Parse(Console.ReadLine());
            short three = short.Parse(Console.ReadLine());
            ushort four = ushort.Parse(Console.ReadLine());
            uint five = uint.Parse(Console.ReadLine());
            int six = int.Parse(Console.ReadLine());
            long seven = long.Parse(Console.ReadLine());

            Console.WriteLine(one);
            Console.WriteLine(two);
            Console.WriteLine(three);
            Console.WriteLine(four);
            Console.WriteLine(five);
            Console.WriteLine(six);
            Console.WriteLine(seven);

        }
    }
}