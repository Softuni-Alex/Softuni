using System;

namespace EnterNumbers
{
    class EnterNumbers
    {
        static void Main()
        {

            const int Start = 1;
            const int End = 100;

            Console.WriteLine("Enter 10 numbers in the range [1-100]: ");

            try
            {
                int num = 0;
                for (int i = 0; i < 10; i++)
                {
                    num = ReadNumber(Start, End);
                }

            }
            catch(ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("\nError!\nNumber was out of range [{0}-{1}]!\n", Start, End);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("\n -> {0} -> {1}\n", e.GetType(), e.Message);
            }
            
        }

        private static int ReadNumber(int start,int end)
        {
            int num = int.Parse(Console.ReadLine());
            if (num<start || num>end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return num;
        }
    }
}
