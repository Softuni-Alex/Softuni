namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Models.Armies;

    [ArmyStructure]
    public class Barracks : ArmyStructure
    {
        private const CityType BarrackRequiredCityType = CityType.Keep;
        private const decimal BarrackBuildCost = 15000;
        private const int BarrackCapacity = 5000;
        private const UnitType BarrackArmyType = UnitType.Infantry;

        public Barracks()
            : base(BarrackRequiredCityType, BarrackBuildCost, BarrackCapacity, BarrackArmyType)
        {
        }
    }
}
