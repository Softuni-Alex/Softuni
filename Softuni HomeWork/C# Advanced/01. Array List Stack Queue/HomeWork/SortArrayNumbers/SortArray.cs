namespace SortArrayNumbers
{
    using System;
    using System.Linq;

    public class SortArray
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Array.Sort(numbers);

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}