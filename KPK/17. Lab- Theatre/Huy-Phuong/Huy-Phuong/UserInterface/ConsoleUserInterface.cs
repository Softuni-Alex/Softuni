namespace Huy_Phuong.UserInterface
{
    using Interfaces;
    using System;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
