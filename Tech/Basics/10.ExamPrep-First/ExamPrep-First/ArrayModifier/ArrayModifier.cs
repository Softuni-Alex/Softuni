using System;
using System.Linq;

namespace ArrayModifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            long[] inputNumbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

            string commands = Console.ReadLine();

            while (commands != "end".ToLower())
            {
                string[] tokens = commands.Split();

                //parsed tokens
                string modify = tokens[0];

                switch (modify)
                {
                    case "swap":
                        long firstIndex = long.Parse(tokens[1]);
                        long secondIndex = long.Parse(tokens[2]);

                        Swap(firstIndex, secondIndex, inputNumbers);
                        break;
                    case "multiply":
                        long indexOne = long.Parse(tokens[1]);
                        long indexTwo = long.Parse(tokens[2]);

                        Multiply(indexOne, indexTwo, inputNumbers);
                        break;
                    case "decrease":
                        Decrease(inputNumbers);
                        break;
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", inputNumbers));

        }

        static void Swap(long firstIndex, long secondIndex, long[] inputNumbers)
        {
            long temp = 0;

            temp = inputNumbers[firstIndex];
            inputNumbers[firstIndex] = inputNumbers[secondIndex];
            inputNumbers[secondIndex] = temp;
        }

        static void Multiply(long indexOne, long indexTwo, long[] inputNumbers)
        {
            long result = inputNumbers[indexOne] *= inputNumbers[indexTwo];
        }

        static void Decrease(long[] inputNumbers)
        {
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                inputNumbers[i] -= 1;
            }
        }
    }
}