using System;
using System.Text;

public class StringBuilderDemo
{
    public static void Main()
    {
        string s = Console.ReadLine();
        StringBuilder sb = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; i--)
        {
            sb.Append(s[i]);
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}
