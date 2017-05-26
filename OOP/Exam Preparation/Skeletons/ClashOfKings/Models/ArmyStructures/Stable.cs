namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Models.Armies;

    [ArmyStructure]
    public class Stable : ArmyStructure
    {
        private const CityType StableRequiredCityType = CityType.FortifiedCity;
        private const decimal StableBuildCost = 75000;
        private const int StableCapacity = 2500;
        private const UnitType StableArmyType = UnitType.Cavalry;

        public Stable()
            : base(StableRequiredCityType, StableBuildCost, StableCapacity, StableArmyType)
        {
        }
    }
}
