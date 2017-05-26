namespace Huy_Phuong.Core
{
    using Exceptions;
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<ITheatre, SortedSet<IPerformance>> theatresPerformances =
            new SortedDictionary<ITheatre, SortedSet<IPerformance>>();

        public void AddTheatre(string theatreName)
        {
            ITheatre theatre = new Theatre(theatreName);

            if (this.theatresPerformances.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theatresPerformances[theatre] = new SortedSet<IPerformance>();
        }

        public IEnumerable<ITheatre> ListTheatres()
        {
            var theatres = this.theatresPerformances.Keys;
            return theatres;
        }

        public void AddPerformance(ITheatre theatre, string performanceName, DateTime date, TimeSpan duration, decimal price)
        {
            if (!this.theatresPerformances.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.theatresPerformances[theatre];

            var endTime = date + duration;
            CheckPerformanceDuration(performances, date, endTime);

            var performance = new Performance(theatre, performanceName, date, duration, price);
            performances.Add(performance);
        }

        public IEnumerable<IPerformance> ListAllPerformances()
        {
            var theatres = this.theatresPerformances.Keys;

            var allTheatresPerformances = new List<IPerformance>();

            foreach (var theatre in theatres)
            {
                var performances = this.theatresPerformances[theatre];
                allTheatresPerformances.AddRange(performances);
            }

            return allTheatresPerformances;
        }

        public IEnumerable<IPerformance> ListPerformances(string theatreName)
        {
            Theatre theatre = new Theatre(theatreName);
            if (!this.theatresPerformances.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }
            var theatrePerformances = this.theatresPerformances[theatre];
            return theatrePerformances;
        }

        private void CheckPerformanceDuration(IEnumerable<IPerformance> performances, DateTime startTime, DateTime endTime)
        {
            foreach (var performance in performances)
            {
                var performanceDate = performance.Date;

                var endPerformanceDate = performance.Date + performance.Duration;
                var isOverLapped = (performanceDate <= startTime && startTime <= endPerformanceDate)
                    || (performanceDate <= endTime && endTime <= endPerformanceDate)
                    || (startTime <= performanceDate && performanceDate <= endTime)
                    || (startTime <= endPerformanceDate && endPerformanceDate <= endTime);

                if (isOverLapped)
                {
                    throw new TimeDurationOverlapException("Time/duration overlap");
                }
            }
        }
    }
}
