using System;
using System.Linq;

namespace HourglassSum
{
    class HourglassSum
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[6, 6];

            //read the matrix
            for (int i = 0; i < 6; i++)
            {
                int[] temp = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < 6; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }

            int maxSum = int.MinValue;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int currentSum = 0;
                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            currentSum += matrix[k, l];
                        }
                    }
                    currentSum -= matrix[i + 1, j];
                    currentSum -= matrix[i + 1, j + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}