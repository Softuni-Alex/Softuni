namespace VegetableNinja.Models.Vegetables
{
    using Interfaces;
    using Position;

    public abstract class Vegetable : GameObject, IVegetable
    {
        protected Vegetable(Position position, char objectSymbol, IPlayer player)
            : base(position, objectSymbol)
        {
        }

        public abstract void Regrow();
    }
}