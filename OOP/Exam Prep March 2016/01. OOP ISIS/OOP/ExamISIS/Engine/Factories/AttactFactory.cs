using ExamISIS.Enums;
using ExamISIS.Interfaces;
using System;

namespace ExamISIS.Engine.Factories
{
    public class AttackFactory : IAttackTypes
    {
        public AttackTypes CreateWarEffect(string attackName)
        {
            switch (attackName.Trim())
            {
                case "Paris":
                    return AttackTypes.Paris;
                case "SU24":
                    return AttackTypes.SU24;

                default:
                    throw new ArgumentException("Unrecognized attack type");
            }
        }
    }
}