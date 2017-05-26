namespace VegetableNinja.UI
{
    using Interfaces;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}