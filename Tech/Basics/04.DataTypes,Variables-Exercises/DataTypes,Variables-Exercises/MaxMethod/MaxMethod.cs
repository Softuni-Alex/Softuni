using System;

namespace MaxMethod
{
    class MaxMethod
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (c > GetMax(a, b))
            {
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine(GetMax(a, b));
            }
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            if (b > a)
            {
                return b;
            }
            return 0;
        }
    }
}