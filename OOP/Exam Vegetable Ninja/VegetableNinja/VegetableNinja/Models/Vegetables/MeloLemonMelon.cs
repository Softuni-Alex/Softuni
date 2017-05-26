namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;

    public class MeloLemonMelon : Vegetable
    {
        private char meloLemonMelon = '*';

        public MeloLemonMelon(Position.Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol, player)
        {
            this.ObjectSymbol = this.meloLemonMelon;
        }

        public override void Regrow()
        {
            throw new System.NotImplementedException();
        }
    }
}