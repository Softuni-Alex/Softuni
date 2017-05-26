using System;

namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            bool areEqual = Math.Abs(a - b) < 0.000001;
            Console.WriteLine(areEqual);
        }
    }
}