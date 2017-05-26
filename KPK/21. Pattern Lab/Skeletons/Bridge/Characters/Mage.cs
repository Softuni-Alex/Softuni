using Bridge.Characters;
using Bridge.Interfaces;

namespace RPG.Characters
{
    public class Mage : Character
    {
        public Mage(IWeapon weapon)
            : base(weapon)
        {

        }

        public IWeapon Weapon { get; }

    }
}
