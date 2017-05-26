namespace Huy_Phuong.Exceptions
{
    using System;

    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string message)
            : base(message)
        {
        }
    }
}

