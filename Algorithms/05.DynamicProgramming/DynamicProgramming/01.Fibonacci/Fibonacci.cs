using System;

namespace _01.Fibonacci
{
    public class Fibonacci
    {
        private static long[] memo;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            memo = new long[n + 1];

            Console.WriteLine(Fib(n));
        }

        private static long Fib(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            if (n <= 2)
            {
                return 1;
            }

            memo[n] = Fib(n - 1) + Fib(n - 2);

            return memo[n];
        }
    }
}