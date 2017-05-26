using Empires.BaseClasses;
using Empires.Interface;
using Empires.Object;
using System.Collections.Generic;

namespace Empires.Engine
{
    class BaseDB : IDataBase
    {
        private List<Building> buildings = new List<Building>();
        private Army army = new Army();
        private Treasury treasury = new Treasury();
        public void AddBuilding(Building building)
        {
            this.buildings.Add(building);
        }
        public void AddUnit(Unit unit)
        {
            this.army.Add(unit);
        }
        public void AddResource(Resource resource)
        {
            this.treasury.Add(resource);
        }
        public ICollection<Building> GetBuildings()
        {
            return this.buildings;
        }
        public Army GetArmy()
        {
            return this.army;
        }
        public Treasury GetTreasury()
        {
            return this.treasury;
        }
        public void IncrementBuildingsCounter()
        {
            foreach (var building in buildings)
            {
                building.Tick();
            }
        }
    }
}
