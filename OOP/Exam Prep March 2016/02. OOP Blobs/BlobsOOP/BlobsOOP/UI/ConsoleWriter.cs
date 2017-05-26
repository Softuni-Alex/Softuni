using System;
using BlobsOOP.Interfaces;

namespace BlobsOOP.UI
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
