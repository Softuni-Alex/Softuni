namespace TheSlum.Items.BonusItems
{
    using TheSlum.Interfaces;

    class Pill : Bonus, ITimeoutable
    {
        public Pill(string id,
            int healthEffect,
            int defenseEffect,
            int attackEffect)
            : base(id,
            healthEffect = 0,
            defenseEffect = 0,
            attackEffect = 100)
        {
            this.Timeout = 1;
            this.Countdown = 1;
            this.HasTimedOut = false;
        }
    }
}