namespace ReverseString
{
    using System;

    class ReverseString
    {
        static void Main()
        {
            //First way

            string input = Console.ReadLine();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }
            Console.WriteLine();


            //Second way

            //string input = Console.ReadLine();

            //char[] arr = input.ToCharArray();

            //Array.Reverse(arr);

            //foreach (var s in arr)
            //{
            //    Console.Write(s);
            //}
            //Console.WriteLine();
        }
    }
}