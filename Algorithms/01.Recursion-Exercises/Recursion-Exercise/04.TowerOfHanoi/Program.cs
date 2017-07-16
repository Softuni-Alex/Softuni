using System;
using System.Collections.Generic;
using System.Linq;

public class TowerOfHanoi
{
    private static Stack<int> source = new Stack<int>(Enumerable.Range(1, 3).Reverse());
    private static Stack<int> spare = new Stack<int>();
    private static Stack<int> destination = new Stack<int>();
    private static int steps = 0;

    public static void Main(string[] args)
    {
        PrintRods();
        Toh(source.Count, source, destination, spare);
    }

    private static void Toh(int count, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (count == 1)
        {
            steps++;
            destination.Push(source.Pop());
            Console.WriteLine($"Step #{steps}: Moved disk");
            PrintRods();
            return;
        }
        else
        {
            Toh(count - 1, source, spare, destination);
            destination.Push(source.Pop());
            Toh(count - 1, spare, destination, source);
        }
    }

    private static void PrintRods()
    {
        Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
        Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
        Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
        Console.WriteLine();
    }
}
