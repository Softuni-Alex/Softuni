using System;

public class Startup
{
    public static void Main()
    {
        ReversedList<int> reverse = new ReversedList<int>();

        reverse.Add(1);
        reverse.Add(2);
        reverse.Add(3);

        Console.WriteLine(reverse.RemoveAt(0));

        Console.WriteLine();

        foreach (var i in reverse)
        {
            Console.WriteLine(i);
        }
    }
}