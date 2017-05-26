namespace RPGGame.Items
{
    public class Beer : Item
    {
        const char BeerSymbol = 'B';

        public Beer(Position position, BeerSize beerSize)
            : base(position, BeerSymbol)
        {
            this.BeerSize = beerSize;
        }

        private BeerSize BeerSize { get; set; }

        public int HealthRestore
        {
            get { return (int)this.BeerSize; }
        }

    }
}
