using System;
using System.Collections.Generic;

namespace PrimesInRange
{
    class PrimesInRange
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int counter = 0;

            FindPrimesInRange(n, m, counter);
        }

        static void FindPrimesInRange(int n, int m, int counter)
        {
            List<int> numbers = new List<int>();
            if (n < 0 || m < 0)
            {
                n = 2;
            }
            if (n == 0 || n == 1)
            {
                n = 2;
            }
            if (n > m)
            {
                Console.WriteLine("Empty list");
            }
            for (int i = n; i <= m; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        counter++;
                    }
                    if (counter > 2)
                    {
                        break;
                    }
                }
                if (counter <= 2)
                {
                    numbers.Add(i);
                }
                counter = 0;
            }

            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine();
        }
    }
}