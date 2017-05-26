using System;
using System.Linq;

namespace Tour
{
    class Tour
    {
        static void Main(string[] args)
        {
            long size = long.Parse(Console.ReadLine());

            long[,] matrix = new long[size, size];

            for (int i = 0; i < size; i++)
            {
                long[] parsedNumbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

                for (int j = 0; j < parsedNumbers.Length; j++)
                {
                    matrix[i, j] = parsedNumbers[j];
                }
            }

            long[] cityOrder = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long distanceSum = 0;
            long currentCity = 0;

            for (int i = 0; i < cityOrder.Length; i++)
            {
                long cityToVisit = cityOrder[i];
                distanceSum += matrix[currentCity, cityToVisit];
                currentCity = cityToVisit;
            }

            Console.WriteLine(distanceSum);
        }
    }
}