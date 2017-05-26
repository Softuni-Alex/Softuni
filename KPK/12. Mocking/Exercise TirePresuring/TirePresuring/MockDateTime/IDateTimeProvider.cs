using System;

namespace MockDateTime
{
    public interface IDateTimeProvider
    {
        DateTime DateTimeNow { get; }
    }
}
