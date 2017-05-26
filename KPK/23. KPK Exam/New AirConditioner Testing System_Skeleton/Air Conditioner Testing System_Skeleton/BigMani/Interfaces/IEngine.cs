namespace AirConditioner.Interfaces
{
    using Commands;

    public interface IEngine
    {
        void Run();

        /// <summary>
        /// Status takes AirConditiner report and conditioner count and returns it in the selected format 
        /// </summary>
        /// <returns>string</returns>
        string Status();

        /// <summary>
        /// Validates the parameters count.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="count">The count.</param>
        void ValidateParametersCount(Command command, int count);
    }
}