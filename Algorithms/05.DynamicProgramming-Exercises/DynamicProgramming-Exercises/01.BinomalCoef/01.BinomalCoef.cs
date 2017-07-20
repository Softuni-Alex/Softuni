using System;

namespace _01.BinomalCoef
{
    public class BinomialCoefficients
    {
        private static long[,] binomialCoefficients;

        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long k = long.Parse(Console.ReadLine());
            binomialCoefficients = new long[n + 1, k + 1];
            Console.WriteLine(CalculateBinaryCoefficient(n, k));
        }

        private static long CalculateBinaryCoefficient(long n, long k)
        {
            if (binomialCoefficients[n, k] != 0)
            {
                return binomialCoefficients[n, k];
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            binomialCoefficients[n, k] = CalculateBinaryCoefficient(n - 1, k - 1) + CalculateBinaryCoefficient(n - 1, k);
            return binomialCoefficients[n, k];
        }
    }
}