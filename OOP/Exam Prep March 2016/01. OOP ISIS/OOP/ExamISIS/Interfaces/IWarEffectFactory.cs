using ExamISIS.Enums;

namespace ExamISIS.Interfaces
{
    public interface IWarEffectFactory
    {
        WarEffect CreateWarEffect(string warName);
    }
}
