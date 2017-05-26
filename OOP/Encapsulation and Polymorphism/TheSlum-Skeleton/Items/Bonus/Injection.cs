namespace TheSlum.Items.BonusItems
{
    using TheSlum.Interfaces;

    class Injection : TheSlum.Bonus, ITimeoutable
    {
        public Injection(string id,
            int healthEffect,
            int defenseEffect,
            int attackEffect)
            : base(id,
                healthEffect = 200,
                defenseEffect = 0,
                attackEffect = 0)
        {
            this.Timeout = 3;
            this.Countdown = 3;
            this.HasTimedOut = false;
        }
    }
}