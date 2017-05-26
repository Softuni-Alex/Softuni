﻿using System;

namespace Empires.CustomException
{
    public class ResourceException : Exception
    {
        public ResourceException()
        {

        }

        public ResourceException(string message)
            : base(message)
        {

        }

        public ResourceException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
