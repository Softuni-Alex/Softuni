namespace VegetableNinja.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string message, params object[] parameters);
    }
}