namespace AirConditioner.Interfaces
{
    public interface IController
    {
        void Commands();

        string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage);

        string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage);

        /// <summary>
        /// Registers plane air conditioner by given parameters.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="volumeCoverage">The volume coverage.</param>
        /// <param name="electricityUsed">The electricity used.</param>
        /// <returns>string</returns>
        string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed);

        string TestAirConditioner(string manufacturer, string model);

        /// <summary>
        /// Finds the air conditioner by given manufacturer and model.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <returns>string</returns>
        string FindAirConditioner(string manufacturer, string model);

        /// <summary>
        /// Finds the report.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <returns>string</returns>
        string FindReport(string manufacturer, string model);

        /// <summary>
        /// Finds all reports by manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <returns>string</returns>
        string FindAllReportsByManufacturer(string manufacturer);
    }
}