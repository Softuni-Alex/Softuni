namespace VegetableNinja.Exceptions
{
    using System;

    public class MovesOutOfRangeException : Exception
    {
        public MovesOutOfRangeException(string message)
            : base(message)
        {
        }
    }
}