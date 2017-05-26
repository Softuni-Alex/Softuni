namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;

    public class Asparagus : Vegetable
    {
        private char asparagusSymbol = 'A';
        private int asparagusMovesToRegrow;

        public Asparagus(Position.Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol, player)
        {
            player.Power += 5;
            player.Stamina -= 5;
            this.ObjectSymbol = this.asparagusSymbol;
            this.asparagusMovesToRegrow = 2;
        }

        public override void Regrow()
        {
            throw new System.NotImplementedException();
        }
    }
}