using System;

namespace Empires.CustomException
{
    public class UnitException : Exception
    {

        public UnitException()
        {

        }

        public UnitException(string message)
            : base(message)
        {

        }

        public UnitException(string message, Exception inner)
            : base(message, inner)
        {

        }

    }
}
