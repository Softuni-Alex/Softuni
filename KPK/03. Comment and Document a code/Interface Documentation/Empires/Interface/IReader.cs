namespace Empires.Interface
{
    /// <summary>
    /// Allowing us to write not only from console
    /// </summary>
    public interface IReader
    {
        void WriteLine(string message, params object[] parameters);
    }
}
