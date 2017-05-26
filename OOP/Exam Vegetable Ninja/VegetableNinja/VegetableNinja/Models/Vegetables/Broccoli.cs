namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;

    public class Broccoli : Vegetable
    {
        private char broccoliSymbol = 'B';
        private int broccoliMovesToRegrow;

        public Broccoli(Position.Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol, player)
        {
            player.Power += 10;
            this.ObjectSymbol = this.broccoliSymbol;
            this.broccoliMovesToRegrow = 3;
        }

        public override void Regrow()
        {
            throw new System.NotImplementedException();
        }
    }
}