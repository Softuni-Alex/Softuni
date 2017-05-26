using System.Collections.Generic;

namespace HotelBookingSystem.Interfaces
{
    public interface IEndpoint
    {
        string ControllerName { get; }

        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}