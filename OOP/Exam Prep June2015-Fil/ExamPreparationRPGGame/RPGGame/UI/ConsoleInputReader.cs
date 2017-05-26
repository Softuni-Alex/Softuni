using RPGGame.Interfaces;
using System;
namespace RPGGame.UI
{
    public class ConsoleInputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
