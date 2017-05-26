using System;

namespace BlobsOOP.Models.Events
{
    public class BlobDeadEventArgs : EventArgs
    {
        public BlobDeadEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
