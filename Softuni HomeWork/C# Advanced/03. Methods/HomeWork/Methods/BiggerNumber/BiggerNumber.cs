namespace BiggerNumber
{
    using System;

    public class BiggerNumber
    {
        private static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int max = GetMax(firstNumber, secondNumber);

            Console.WriteLine(max);
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            if (secondNumber > firstNumber)
            {
                return secondNumber;
            }
            return firstNumber;
        }
    }
}