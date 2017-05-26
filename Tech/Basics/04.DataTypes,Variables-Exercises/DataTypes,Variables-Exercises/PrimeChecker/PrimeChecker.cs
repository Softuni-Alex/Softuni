using System;

namespace PrimeChecker
{
    class PrimeChecker
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(n));
        }

        private static bool IsPrime(long i)
        {
            if (i <= 1)
            {
                return false;
            }
            int maxDivider = (int)Math.Sqrt(i);
            for (long j = 2; j <= maxDivider; j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}