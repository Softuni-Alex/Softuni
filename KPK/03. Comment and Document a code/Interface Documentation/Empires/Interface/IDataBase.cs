using Empires.BaseClasses;
using Empires.Object;
using System.Collections.Generic;

namespace Empires.Interface
{
    /// <summary>
    /// Representing a data base we can use for a polymorphism later on
    /// </summary>
    public interface IDataBase
    {
        void AddBuilding(Building building);
        void AddUnit(Unit unit);
        void AddResource(Resource resource);
        void IncrementBuildingsCounter();
        ICollection<Building> GetBuildings();
        Army GetArmy();
        Treasury GetTreasury();
    }
}
