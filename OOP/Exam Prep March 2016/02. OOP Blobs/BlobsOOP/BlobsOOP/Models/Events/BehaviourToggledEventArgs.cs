using System;

namespace BlobsOOP.Models.Events
{
    public class BehaviorToggledEventArgs : EventArgs
    {
        public BehaviorToggledEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
