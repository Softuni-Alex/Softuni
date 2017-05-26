
namespace BookStore.UI
{
    using BookStore.Interfaces;
    using System;

    public class ConsoleInputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
