using Bridge.Characters;
using Bridge.Interfaces;

namespace RPG.Characters
{
    public class Warrior : Character
    {
        public Warrior(IWeapon weapon)
            : base(weapon)
        {

        }
        public IWeapon weapon { get; }
    }
}
