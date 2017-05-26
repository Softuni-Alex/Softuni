using Bridge.Interfaces;

namespace RPG.Weapons
{
    public class Sword : IWeapon
    {
        public override string ToString()
        {
            string result = "a Sword";
            return result;
        }
    }
}
