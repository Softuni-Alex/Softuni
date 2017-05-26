namespace VegetableNinja.Models.Characters
{
    public class Ninja : Player
    {
        public Ninja(Position.Position position, char objectSymbol, int stamina, int power, string name)
            : base(position, objectSymbol, stamina, power, name)
        {
        }
    }
}