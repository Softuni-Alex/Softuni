using RPGGame.Attributes;

namespace RPGGame.Characters
{
    [Enemy]
    public class Fairy : Character
    {
        private const int FairyDamage = 100;
        private const int FairyHealth = 60;
        private const char FairySymbol = 'F';

        public Fairy(Position position, string name)
            : base(position, FairySymbol, FairyDamage, FairyHealth, name)
        {
        }
    }
}
