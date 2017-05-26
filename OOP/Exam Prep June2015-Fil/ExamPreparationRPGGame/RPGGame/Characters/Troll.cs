using RPGGame.Attributes;

namespace RPGGame.Characters
{
    [Enemy]
    public class Troll : Character
    {

        private const int TrollDamage = 75;
        private const int TrollHealth = 400;
        private const char TrollSymbol = 'T';

        public Troll(Position position, string name)
               : base(position, TrollSymbol, TrollDamage, TrollHealth, name)
        {



        }
    }
}
