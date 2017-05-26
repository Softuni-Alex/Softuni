
namespace BookStore.UI
{
    using BookStore.Interfaces;
    using System;

    public class ConsoleRenderer : IRenderer
    {

        public void WriteLine(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }

    }
}
