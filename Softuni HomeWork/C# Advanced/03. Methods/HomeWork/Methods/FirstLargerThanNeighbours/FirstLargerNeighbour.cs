namespace FirstLargerThanNeighbours
{
    using System;

    public class FirstLargerNeighbour
    {
        public static void Main()
        {
            int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
            int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
            int[] sequenceThree = { 1, 1, 1 };

            Console.WriteLine(GeIndexOfFirstElementLargerThanNeighbours(sequenceOne));
            Console.WriteLine(GeIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
            Console.WriteLine(GeIndexOfFirstElementLargerThanNeighbours(sequenceThree));
        }

        private static int GeIndexOfFirstElementLargerThanNeighbours(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (IsLargerThanNeighbours(sequence, i))
                {
                    return i;
                }
            }
            return -1;
        }

        private static bool IsLargerThanNeighbours(int[] numbers, int i)
        {
            bool isLarger = false;

            if (i == 0)
            {
                isLarger = numbers[i + 1] < numbers[i];
            }
            else if (i > 0 && i < numbers.Length - 1)
            {
                isLarger = numbers[i - 1] < numbers[i] && numbers[i + 1] < numbers[i];
            }
            else
            {
                isLarger = numbers[i - 1] < numbers[i];
            }
            return isLarger;
        }

    }
}