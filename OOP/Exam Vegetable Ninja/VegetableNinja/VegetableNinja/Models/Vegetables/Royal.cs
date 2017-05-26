namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;

    public class Royal : Vegetable
    {
        private char royalSymbol = 'R';
        private int royalMovesToRegrow;

        public Royal(Position.Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol, player)
        {
            player.Power += 20;
            player.Stamina += 10;
            this.ObjectSymbol = this.royalSymbol;
            this.royalMovesToRegrow = 10;
        }

        public override void Regrow()
        {
            throw new System.NotImplementedException();
        }
    }
}