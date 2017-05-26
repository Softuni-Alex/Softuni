using ExamISIS.Enums;

namespace ExamISIS.Interfaces
{
    public interface IHackGroups
    {
        string Name { get; }

        int Health { get; set; }

        int InitialHealth { get; set; }

        int Damage { get; }

        WarEffect WarEffect { get; }

        AttackTypes GroupAttackType { get; }

        bool TriggerWarEffect { get; set; }

        bool IsEffectTriggered { get; set; }

        void ApplyWarEffect();

        void Attack(IHackGroups targetGroup);

        void Update();

        void CheckIfEffectShouldBeTriggered();

        void CheckIfEffectShouldBeTriggeredTarget(IHackGroups targetGroup);
    }
}