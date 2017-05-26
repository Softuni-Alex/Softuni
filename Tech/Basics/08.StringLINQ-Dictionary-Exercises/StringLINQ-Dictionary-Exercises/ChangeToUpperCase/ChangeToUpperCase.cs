using System;

namespace ChangeToUpperCase
{
    class ChangeToUpperCase
    {
        static void Main(string[] args)
        {
        string text = Console.ReadLine(); 
        Console.WriteLine(Regex.Replace(text, "<upcase>(.*?)</upcase>", word => word.Groups[1].Value.ToUpper()));
        }
    }
}