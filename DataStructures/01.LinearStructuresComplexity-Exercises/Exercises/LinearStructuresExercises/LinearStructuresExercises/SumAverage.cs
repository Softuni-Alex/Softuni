using System;
using System.Collections.Generic;
using System.Linq;

public class SumAverage
{
    public static void Main(string[] args)
    {
        List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        float sum = 0;
        float average = 0f;

        for (int i = 0; i < sequence.Count; i++)
        {
            sum += sequence[i];
        }

        average = (float)Math.Round(sum / sequence.Count, 2, MidpointRounding.AwayFromZero);

        Console.WriteLine($"Sum={sum}; Average={average:f2}");
    }
}
