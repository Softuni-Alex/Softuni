namespace ClashOfKings.Models.Commands
{
    using System;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class BuildStructureCommand : Command
    {
        public BuildStructureCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            ICity city = this.Engine.Continent.GetCityByName(commandParams[1]);

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            IArmyStructure structure = this.Engine.ArmyStructureFactory.CreateStructure(commandParams[0]);

            if (city.CityType < structure.RequiredCityType)
            {
                throw new InsufficientCitySizeException("Structure requires a more advanced city");
            }

            if (city.ControllingHouse.TreasuryAmount < structure.BuildCost)
            {
                throw new InsufficientFundsException(
                    $"House {city.ControllingHouse.Name} doesn't have sufficient funds to build {structure.GetType().Name}");
            }

            city.ControllingHouse.TreasuryAmount -= structure.BuildCost;
            city.AddArmyStructure(structure);

            this.Engine.Render("Successfully built {0} in {1}", structure.GetType().Name, city.Name);
        }
    }
}
