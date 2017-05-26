using Empires.Interface;
using System;

namespace Empires.UI
{
    public class ConsoleReader : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
