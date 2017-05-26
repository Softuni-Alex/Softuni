using System;

namespace ArraysExercises
{
    class Problem01
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ');
            string[] array2 = Console.ReadLine().Split(' ');

            int leftLenght = 0;
            int rightLenght = 0;
            int minLenght = Math.Min(array1.Length, array2.Length);

            for (int i = 0; i < minLenght; i++)
            {
                if (array1[i] == array2[i])
                {
                    leftLenght++;
                }
                else
                {
                    break;
                }
            }
            for (int i = array1.Length - 1, j = array2.Length - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (array1[i] == array2[j])
                {
                    rightLenght++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(Math.Max(leftLenght, rightLenght));
        }
    }
}
