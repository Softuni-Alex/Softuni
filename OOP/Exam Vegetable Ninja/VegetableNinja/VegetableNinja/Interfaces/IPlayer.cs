namespace VegetableNinja.Interfaces
{
    using Models.Vegetables;
    using System.Collections.Generic;

    public interface IPlayer : IMovable, IPosition, IEatable, ICollectable
    {
        string Name { get; set; }
        int Stamina { get; set; }
        int Power { get; set; }
        IEnumerable<Vegetable> Vegetables { get; }
    }
}