using System;

namespace ReverseNumber
{
    public class ReverseNumber
    {
        public static void Main()
        {
            double number = double.Parse(Console.ReadLine());

            double reversed = GetReversedNumber(number);

            Console.WriteLine(reversed);
        }

        private static double GetReversedNumber(double num)
        {
            string number = num.ToString();
            char[] reverse = number.ToCharArray();
            Array.Reverse(reverse);
            string revNum = new string(reverse);
            double newNum = double.Parse(revNum);

            return newNum;
        }
    }
}