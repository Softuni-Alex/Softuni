using Huy_Phuong.Exceptions;

namespace Huy_Phuong.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Add theatre by given theatre name
        /// </summary>
        /// <param name="theatreName">Name of the theatre.</param>
        /// <returns>Theatre</returns>
        /// <exception cref="DuplicateTheatreException"></exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// List all the available theatres 
        /// </summary>
        /// <returns>Theaters</returns>
        /// <exception cref="TheatreNotFoundException"></exception>
        IEnumerable<ITheatre> ListTheatres();

        /// <summary>
        /// Add a performance to the theatre with the specified parameters
        /// </summary>
        /// <param name="theatreName"></param>
        /// <param name="performanceTitle"></param>
        /// <param name="startDateTime"></param>
        /// <param name="duration"></param>
        /// <param name="price"></param>
        /// <returns>Performance added</returns>
        /// <exception cref="TheatreNotFoundException"></exception>
        void AddPerformance(ITheatre theatre, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Lists all available performances.
        /// </summary>
        /// <returns>performances</returns>
        /// <exception cref="">No performances found</exc
        IEnumerable<IPerformance> ListAllPerformances();

        /// <summary>
        /// Lists all the performances with a given theatre name
        /// </summary>
        /// <param name="theatreName">Name of the theatre.</param>
        /// <returns>all performances with this name</returns>
        /// <exception cref="">No performances found</exception>
        IEnumerable<IPerformance> ListPerformances(string theatreName);
    }
}

