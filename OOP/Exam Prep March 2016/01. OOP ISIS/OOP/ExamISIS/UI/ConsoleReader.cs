using System;
using ExamISIS.Interfaces;

namespace ExamISIS.UI
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}