using ExamISIS.Interfaces;
using System;

namespace ExamISIS.UI
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
