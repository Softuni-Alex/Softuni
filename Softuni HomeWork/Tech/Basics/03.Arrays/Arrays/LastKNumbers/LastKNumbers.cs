using System;

namespace LastKNumbers
{
    class LastKNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            decimal[] seq = new decimal[n];
            seq[0] = 1;

            for (int i = 1; i < n; i++)
            {
                seq[i] = SumNums(seq, i - k, i - 1);
            }
            Console.WriteLine("Sequence: ");
            Console.WriteLine(String.Join(" ", seq));
        }

        private static decimal SumNums(decimal[] seq, int startIndex, int endIndex)
        {
            decimal sum = 0;
            for (int j = startIndex; j <= endIndex; j++)
            {
                if (j >= 0)
                {
                    sum += seq[j];
                }
            }
            return sum;
        }
    }
}