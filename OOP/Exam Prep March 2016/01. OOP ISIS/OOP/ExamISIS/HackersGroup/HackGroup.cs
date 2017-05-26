using ExamISIS.Enums;
using ExamISIS.Interfaces;
using System.Text;

namespace ExamISIS.HackersGroup
{
    public class HackGroup : IHackGroups
    {
        private string name;
        private int health;
        private int damage;
        private int initialHealth;
        private int initialDamage;
        private const int DefaultDamageBooster = 2;
        private const int DefaultKamikazeBooster = 50;

        private bool isEffectTriggered;

        public HackGroup(string name, int health, int damage, WarEffect warEffect, AttackTypes groupAttackType)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.WarEffect = warEffect;
            this.GroupAttackType = groupAttackType;

            this.InitialHealth = this.Health;
            this.initialDamage = damage;
        }

        public string Name { get; set; }

        public int Health
        {
            get
            {
                if (this.health < 0)
                {
                    this.health = 0;
                }
                return this.health;
            }
            set { this.health = value; }
        }

        public int InitialHealth { get; set; }

        public int Damage
        {
            get
            {
                if (this.damage <= this.initialDamage)
                {
                    this.damage = this.initialDamage;
                }
                return this.damage;
            }
            set { this.damage = value; }
        }

        public WarEffect WarEffect { get; }

        public AttackTypes GroupAttackType { get; }

        public bool TriggerWarEffect { get; set; }

        public bool IsEffectTriggered { get; set; }





        public void ApplyWarEffect()
        {
            switch (this.WarEffect)
            {
                case WarEffect.Jihad:
                    this.Damage *= DefaultDamageBooster;
                    this.IsEffectTriggered = true;
                    break;

                case WarEffect.Kamikaze:
                    this.Health += DefaultKamikazeBooster;
                    this.IsEffectTriggered = true;
                    break;
            }
        }

        public void Attack(IHackGroups targetGroup)
        {
            switch (this.GroupAttackType)
            {
                case AttackTypes.Paris:

                    targetGroup.Health -= this.Damage;
                    this.CheckIfEffectShouldBeTriggeredTarget(targetGroup);
                    break;

                case AttackTypes.SU24:

                    this.Health -= this.Health / 2;
                    this.CheckIfEffectShouldBeTriggered();
                    if (this.Health <= 0)
                    {
                        this.Health = 1;
                    }

                    targetGroup.Health -= this.Damage * DefaultDamageBooster;
                    this.CheckIfEffectShouldBeTriggeredTarget(targetGroup);
                    break;
            }
        }

        public void Update()
        {
            if (this.IsEffectTriggered)
            {
                switch (this.WarEffect)
                {
                    case WarEffect.Jihad:
                        this.Damage -= 5;
                        break;

                    case WarEffect.Kamikaze:
                        this.Health -= 10;
                        break;
                }
            }

            // if the health becomes less than or equal half the inital
            if (this.TriggerWarEffect && this.IsEffectTriggered == false)
            {
                this.ApplyWarEffect();
            }
        }

        public void CheckIfEffectShouldBeTriggered()
        {
            if (this.Health <= this.initialHealth / 2)
            {
                this.TriggerWarEffect = true;
            }
            else
            {
                this.TriggerWarEffect = false;
            }
        }

        public void CheckIfEffectShouldBeTriggeredTarget(IHackGroups targetGroup)
        {
            if (targetGroup.Health <= targetGroup.InitialHealth / 2)
            {
                targetGroup.TriggerWarEffect = true;
            }
            else
            {
                targetGroup.TriggerWarEffect = false;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            //Group Cenko: 50 HP, 15 Damage
            //Group {name}: {health} HP, {damage} Damage
            result.AppendFormat("Group {0}: {1} HP, {2} Damage",
                this.Name,
                this.Health,
                this.Damage)
                .AppendLine();

            return result.ToString();
        }
    }
}