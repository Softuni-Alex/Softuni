﻿namespace Huy_Phuong.Exceptions
{
    using System;

    public class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException(string message)
            : base(message)
        {
        }
    }
}

