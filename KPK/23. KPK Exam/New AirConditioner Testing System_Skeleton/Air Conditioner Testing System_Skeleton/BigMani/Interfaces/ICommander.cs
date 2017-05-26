namespace AirConditioner.Interfaces
{
    public interface ICommander
    {
        string Name { get; }

        string[] Parameters { get; }
    }
}