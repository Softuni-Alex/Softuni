using System;

class Program
{
    public static void Main(string[] args)
    {
        var stack = new ArrayStack<int>();

        stack.Push(2);
        stack.Push(1);
        stack.Push(3);
        stack.Push(5);

        var num = stack.Pop();

        Console.WriteLine(num);

        var asd = stack.ToArray();

        foreach (var i in asd)
        {
            Console.WriteLine(i);
        }
    }
}
