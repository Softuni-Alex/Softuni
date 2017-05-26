namespace LastDigitOfNumber
{
    using System;

    public class LastDigitOfNumber
    {
        private static void Main()
        {
            Console.WriteLine(GetLastDigitAsWord(51221));
            Console.WriteLine(GetLastDigitAsWord(10245));
            Console.WriteLine(GetLastDigitAsWord(1230923));
        }

        public static string GetLastDigitAsWord(int number)
        {
            int lastDigit = number % 10;

            switch (lastDigit)
            {
                case 0:
                    Console.Write("zero");
                    break;
                case 1:
                    Console.Write("one");
                    break;
                case 2:
                    Console.Write("two");
                    break;
                case 3:
                    Console.Write("three");
                    break;
                case 4:
                    Console.Write("four");
                    break;
                case 5:
                    Console.Write("five");
                    break;
                case 6:
                    Console.Write("six");
                    break;
                case 7:
                    Console.Write("seven");
                    break;
                case 8:
                    Console.Write("eight");
                    break;
                case 9:
                    Console.Write("nine");
                    break;
            }
            return null;
        }
    }
}