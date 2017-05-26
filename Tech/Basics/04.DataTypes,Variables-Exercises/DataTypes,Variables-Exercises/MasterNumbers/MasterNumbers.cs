using System;

namespace MasterNumbers
{
    class MasterNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                if (IsPalindrome(i) && ContainsEvenDigit(i) && SumOfDigits(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsPalindrome(int num)
        {
            bool isPalindrome = true;

            string normal = num.ToString();

            for (int i = 0; i < normal.Length / 2; i++)
            {
                if (normal[i] != normal[normal.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        static bool SumOfDigits(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num = num / 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            return false;
        }

        static bool ContainsEvenDigit(int num)
        {
            bool containsEven = false;

            while (num > 0)
            {
                int lastDigit = num % 10;
                num = num / 10;

                if (lastDigit % 2 == 0)
                {
                    containsEven = true;
                    break;
                }

            }
            if (containsEven)
            {
                return true;
            }
            return false;
        }
    }
}