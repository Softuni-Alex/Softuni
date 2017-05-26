namespace TirePresuring
{
    public interface IAlarm
    {
        void Check();

        bool AlarmOn { get; }
    }
}