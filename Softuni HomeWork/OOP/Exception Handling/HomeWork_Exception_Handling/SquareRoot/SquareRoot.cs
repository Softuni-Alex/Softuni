using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {



            try
            {
                Console.Write("Enter a positive integer number ");
                uint num = uint.Parse(Console.ReadLine());
                Console.WriteLine("{0:F2}",Math.Sqrt(num));
            }
            catch
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }


        }
    }
}
