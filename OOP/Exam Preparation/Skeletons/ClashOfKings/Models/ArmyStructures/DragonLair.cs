namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Models.Armies;

    [ArmyStructure]
    public class DragonLair : ArmyStructure
    {
        private const CityType DragonLairRequiredCityType = CityType.Capital;
        private const decimal DragonLairBuildCost = 200000;
        private const int DragonLairCapacity = 3;
        private const UnitType DragonLairArmyType = UnitType.AirForce;

        public DragonLair()
            : base(DragonLairRequiredCityType, DragonLairBuildCost, DragonLairCapacity, DragonLairArmyType)
        {
        }
    }
}
