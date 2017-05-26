namespace ClashOfKings.Models.Commands
{
    using System;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityName = commandParams[0];
            var city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            city.ControllingHouse.UpgradeCity(city);
            this.Engine.Render($"City {city.Name} successfully upgraded to {city.CityType}");
        }
    }
}
