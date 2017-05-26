using ExamISIS.Enums;
using ExamISIS.Interfaces;
using System;

namespace ExamISIS.Engine.Factories
{
    public class WarEffectFactory : IWarEffectFactory
    {
        public WarEffect CreateWarEffect(string warName)
        {
            switch (warName.Trim())
            {
                case "Jihad":
                    return WarEffect.Jihad;
                case "Kamikaze":
                    return WarEffect.Kamikaze;

                default:
                    throw new ArgumentException("Unrecognized War type.");
            }
        }
    }
}