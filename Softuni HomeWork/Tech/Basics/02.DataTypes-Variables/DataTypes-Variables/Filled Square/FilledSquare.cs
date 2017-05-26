using System;

namespace Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            //top
            Console.WriteLine(new string('-', size * 2));

            //mid
            for (int i = 0; i < size - 2; i++)
            {
                Console.Write('-');
                for (int j = 1; j < size; j++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine('-');
            }

            //bot
            Console.WriteLine(new string('-', size * 2));
        }
    }
}