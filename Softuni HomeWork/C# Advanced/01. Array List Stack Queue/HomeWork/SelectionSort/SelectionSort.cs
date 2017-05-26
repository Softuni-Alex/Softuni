using System.Collections.Generic;

namespace SelectionSort
{
    using System;
    using System.Linq;

    public class SelectionSort
    {
        public static void Main()
        {
            //int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();

            //for (int i = 0; i < numbers.Length - 1; i++)
            //{
            //    int min = i;
            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        if (numbers[j] < numbers[min])
            //        {
            //            min = j;
            //        }

            //    }
            //    int temp = numbers[i];
            //    numbers[i] = numbers[min];
            //    numbers[min] = temp;
            //}

            //foreach (var number in numbers)
            //{
            //    Console.Write(number + " ");
            //}

































            string[] lineOne = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] lineTwo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> mainList = new List<int>();
            List<int> listForFormatting = new List<int>();

            for (int i = 0; i < lineOne.Length; i++)
            {
                listForFormatting.Add(int.Parse(lineOne[i]));
            }
            for (int j = 0; j < lineTwo.Length; j++)
            {
                listForFormatting.Add(int.Parse(lineTwo[j]));
            }

            mainList = listForFormatting.Distinct().ToList();

            foreach (var main in mainList)
            {
                Console.Write(main + " ");
            }
        }
    }
}