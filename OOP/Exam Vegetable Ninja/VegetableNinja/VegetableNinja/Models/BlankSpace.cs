namespace VegetableNinja.Models
{
    public class BlankSpace : GameObject
    {
        private char blankSpaceSymbol = '-';

        public BlankSpace(Position.Position position, char objectSymbol)
            : base(position, objectSymbol)
        {
            this.ObjectSymbol = this.blankSpaceSymbol;
        }
    }
}