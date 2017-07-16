using System;

namespace _07.NChooseKCount
{
    public class NChooseKCount
    {
        static long[,] binomCoeff = new long[100, 100];

        static long Binom(int n, int k)
        {
            if (k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;
            if (binomCoeff[n, k] == 0)
                binomCoeff[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);
            return binomCoeff[n, k];
        }

        public static void Main(String[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n, k));
        }
    }
}
