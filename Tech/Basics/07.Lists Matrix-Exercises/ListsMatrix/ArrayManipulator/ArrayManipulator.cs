using System;
using System.Linq;
using System.Collections.Generic;
 
class Program
{
    static void Main()
    {
        List<int> a = Console.ReadLine().Split().Select(int.Parse).ToList();
        string input = Console.ReadLine();
 
        while (!input.Contains("print"))
        {
            if (input.Contains("sumPairs"))
                SumPairs(ref a);
            else if (input.Contains("add"))
                AddMany(ref a, input);
            else if (input.Contains("contains"))
                Contains(a, input);
            else if (input.Contains("shift"))
                Shift(ref a, input);
            else if (input.Contains("remove"))
                Remove(ref a, input);
 
            input = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", a));
    }
 
    static void SumPairs(ref List<int> a)
    {
        int b = a.Count / 2;
        for (int i = 0; i < b; i++)
        {
            a[i] += a[i + 1]; a.RemoveAt(i + 1);
        }
    }
    static int[] SplitContent(string input)
    {
        string[] args = input.Split();
        int[] arguments = new int[args.Length - 1];
        for (int i = 1; i < args.Length; i++)
        {
            arguments[i - 1] = int.Parse(args[i]);
        }
        return arguments;
    }
    static void AddMany(ref List<int> a, string input)
    {
        int[] arguments = SplitContent(input);
        a.InsertRange(arguments[0], arguments);
        a.RemoveAt(arguments[0]);
    }
    static void Contains(List<int> a, string input)
    {
        int[] arguments = SplitContent(input);
        Console.WriteLine(a.IndexOf(arguments[0]));
    }
    static void Shift(ref List<int> a, string input)
    {
        int[] arguments = SplitContent(input);
        int b = arguments[0] % a.Count;
        for (int i = 0; i < b; i++)
        {
            a.Add(a[0]); a.RemoveAt(0);
        }
    }
    static void Remove(ref List<int> a, string input)
    {
        int[] arguments = SplitContent(input);
        a.RemoveAt(arguments[0]);
    }
}