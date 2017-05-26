namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;

    public class CherryBerry : Vegetable
    {
        private char cherryBerrySymbol = 'C';
        private int cherryBerryMovesToRegrow;

        public CherryBerry(Position.Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol, player)
        {
            player.Stamina += 10;
            this.ObjectSymbol = this.cherryBerrySymbol;
            this.cherryBerryMovesToRegrow = 5;
        }

        public override void Regrow()
        {
            throw new System.NotImplementedException();
        }
    }
}