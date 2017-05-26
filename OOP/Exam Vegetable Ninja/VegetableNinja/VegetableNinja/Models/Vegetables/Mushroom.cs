namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;

    public class Mushroom : Vegetable
    {
        private char mushroomSymbol = 'M';
        private int mushroomMovesToRegrow;

        public Mushroom(Position.Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol, player)
        {
            player.Power -= 10;
            player.Stamina -= 10;
            this.ObjectSymbol = this.mushroomSymbol;
            this.mushroomMovesToRegrow = 5;
        }

        public override void Regrow()
        {
            throw new System.NotImplementedException();
        }
    }
}