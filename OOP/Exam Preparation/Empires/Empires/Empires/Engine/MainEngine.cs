using Empires.Interface;
using Empires.Object;
using System;

namespace Empires.Engine
{
    public class MainEngine
    {
        private readonly IReader reader;
        private readonly IInputHandler input;
        private IDataBase db;

        public MainEngine(IReader read, IInputHandler inputHandler, IDataBase db)
        {
            this.reader = read;
            this.input = inputHandler;
            this.db = db;
        }

        public void Run()
        {
            while (true)
            {
                string line = input.ReadLine();
                if (line == "armistice") break;
                try
                {
                    this.executeCommand(line);
                }
                catch (ArgumentException e)
                {
                    reader.WriteLine(e.Message);
                }
            }
        }

        private void executeCommand(string command)
        {
            switch (command)
            {
                case "skip":
                    this.ProcessTurn();
                    return;
                case "build barracks":
                    this.ProcessTurn();
                    db.AddBuilding(new Barracks());
                    break;
                case "build archery":
                    this.ProcessTurn();
                    db.AddBuilding(new Archery());
                    break;
                case "empire-status":
                    this.ShowStatus();
                    this.ProcessTurn();
                    break;
                default:
                    throw new ArgumentException("Invalid Command");
            }
        }

        private void ShowStatus()
        {
            reader.WriteLine(this.db.GetTreasury().ToString());
            reader.WriteLine("Buildings:");
            if (this.db.GetBuildings().Count == 0)
                reader.WriteLine("N/A");
            foreach (var building in this.db.GetBuildings())
                reader.WriteLine(building.ToString());
            reader.WriteLine(this.db.GetArmy().ToString());
        }

        private void ProcessTurn()
        {
            db.IncrementBuildingsCounter();
            foreach (Building building in this.db.GetBuildings())
            {
                try
                {
                    db.AddUnit(building.GetUnit());
                }
                catch { }
                try
                {
                    db.AddResource(building.GetResource());
                }
                catch { }
            }
        }

    }
}
