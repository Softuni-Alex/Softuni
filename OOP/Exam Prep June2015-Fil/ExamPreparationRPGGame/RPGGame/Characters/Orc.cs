using RPGGame.Attributes;

namespace RPGGame.Characters
{
    [Enemy]
    public class Orc : Character
    {

        private const int OrkDamage = 100;
        private const int OrkHealth = 150;
        private const char OrkSymbol = 'O';

        public Orc(Position position, string name)
            : base(position, OrkSymbol, OrkDamage, OrkHealth, name)
        {



        }
    }
}
