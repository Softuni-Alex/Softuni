namespace _1.Pyramid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pyramid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>();
            int previousNumber = int.Parse(Console.ReadLine().Trim());
            sequence.Add(previousNumber);

            for (int i = 1; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                int minNumber = int.MaxValue;
                bool foundNumber = false;
                for (int j = 0; j < numbers.Length; j++)
                {
                    int currentNumber = numbers[j];
                    if (currentNumber < minNumber && currentNumber > previousNumber)
                    {
                        minNumber = currentNumber;
                        foundNumber = true;
                    }
                }

                if (foundNumber)
                {
                    sequence.Add(minNumber);
                    previousNumber = minNumber;
                }
                else
                {
                    previousNumber++;
                }
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
