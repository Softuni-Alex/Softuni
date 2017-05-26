namespace ClashOfKings.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ClashOfKings.Contracts;

    public class GreatHouse : House
    {
        public GreatHouse(string name, decimal initialTreasuryAmount, IEnumerable<ICity> cities)
            : base(name, initialTreasuryAmount)
        {
            this.AddAllCitiesToHouse(cities);
        }
        
        public override decimal TreasuryAmount { get; set; }

        public override void UpgradeCity(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            this.TreasuryAmount -= city.UpgradeCost;
            city.Upgrade();
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder("Great ");
            result.Append(base.Print());

            return result.ToString();
        }

        private void AddAllCitiesToHouse(IEnumerable<ICity> cities)
        {
            foreach (var city in cities)
            {
                this.AddCityToHouse(city);
            }
        }
    }
}
