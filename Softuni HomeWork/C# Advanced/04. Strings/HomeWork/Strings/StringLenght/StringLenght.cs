using System;
using System.Text;

namespace StringLenght
{
    class StringLenght
    {
        static void Main()
        {
            const int maxLenght = 20;
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            output.Append(input);

            if (output.Length < 20)
            {
                output.Append(new string('*', maxLenght - output.Length));
            }
            else if (output.Length > 20)
            {
                output.Remove(maxLenght, output.Length - 20);
            }
            Console.WriteLine(output);
        }
    }
}