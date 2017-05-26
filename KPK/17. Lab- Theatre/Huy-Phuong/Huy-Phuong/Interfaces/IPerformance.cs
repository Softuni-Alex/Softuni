using System;

namespace Huy_Phuong.Interfaces
{
    public interface IPerformance : IComparable
    {
        DateTime Date { get; }

        TimeSpan Duration { get; }

        ITheatre Theatre { get; }

        string PerformanceName { get; }

        decimal Price { get; }
    }
}
