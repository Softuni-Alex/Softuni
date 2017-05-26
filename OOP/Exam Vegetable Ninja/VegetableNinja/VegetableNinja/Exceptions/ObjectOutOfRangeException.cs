namespace VegetableNinja.Exceptions
{
    using System;

    public class ObjectOutOfRangeException : Exception
    {
        public ObjectOutOfRangeException(string message)
            : base(message)
        {
        }
    }
}