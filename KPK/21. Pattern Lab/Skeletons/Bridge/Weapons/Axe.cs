using Bridge.Interfaces;

namespace RPG.Weapons
{
    public class Axe : IWeapon
    {
        public override string ToString()
        {
            string result = "an Axe";
            return result;
        }
    }
}
