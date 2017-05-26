using Bridge.Interfaces;

namespace Bridge.Characters
{
    public abstract class Character : ICharacter
    {
        protected Character(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public IWeapon weapon { get; }

        public override string ToString()
        {
            string result = string.Format("{0} wield: {1}", this.GetType().Name, this.weapon);
            return result;
        }
    }
}
