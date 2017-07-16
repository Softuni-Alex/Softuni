using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int element = int.Parse(Console.ReadLine());

        int result = BinarySearch.IndexOf(array, element);

        Console.WriteLine(result);
    }
}