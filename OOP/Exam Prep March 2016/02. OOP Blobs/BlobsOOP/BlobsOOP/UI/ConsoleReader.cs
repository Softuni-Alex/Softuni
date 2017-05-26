using System;
using BlobsOOP.Interfaces;

namespace BlobsOOP.UI
{
    public class ConsoleInputReader : IInputReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
