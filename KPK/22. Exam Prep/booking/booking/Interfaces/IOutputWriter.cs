namespace HotelBookingSystem.Interfaces
{
    public interface IOutputWriter
    {
        void WriteLine(string text);

        void Write(string text);
    }
}