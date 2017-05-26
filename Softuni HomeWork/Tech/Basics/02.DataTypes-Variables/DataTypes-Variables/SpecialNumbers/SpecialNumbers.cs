using System;

namespace SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                bool special = IsNumberSpecial(i);

                Console.WriteLine("{0} -> {1}", i, special);
            }
        }

        private static bool IsNumberSpecial(int i)
        {
            int sumOfDigits = CalculateSum(i);
            bool special = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;
            return special;
        }

        private static int CalculateSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += (num % 10);
                num = num / 10;
            }
            return sum;
        }
    }
}