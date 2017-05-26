using Empires.Interface;
using System;

namespace Empires.UI
{
    public class ConsoleRenderer : IReader
    {
        public void WriteLine(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}
