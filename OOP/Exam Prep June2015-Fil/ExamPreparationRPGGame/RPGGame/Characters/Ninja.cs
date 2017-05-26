using RPGGame.Attributes;

namespace RPGGame.Characters
{
    [Enemy]
    public class Ninja : Character
    {
        private const int NinjaDamage = 150;
        private const int NinjaHealth = 300;
        private const char NinjaSymbol = 'N';

        public Ninja(Position position, string name)
            : base(position, NinjaSymbol, NinjaDamage, NinjaHealth, name)
        {

        }
    }
}
