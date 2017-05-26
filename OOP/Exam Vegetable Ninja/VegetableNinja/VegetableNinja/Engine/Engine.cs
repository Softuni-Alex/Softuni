namespace VegetableNinja.Engine
{
    using Interfaces;
    using Models;
    using Models.Vegetables;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private IPlayer player;

        private IList<GameObject> characters;
        private IList<GameObject> vegetables;

        private int row = int.Parse(Console.ReadLine());
        private int col = int.Parse(Console.ReadLine());



        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;

            while (this.IsRunning)
            {
                string command = this.reader.ReadLine();
            }
        }

        private void MovePlayer(string command)
        {
            this.player.Move(command);

            IPlayer enemy =
                this.characters.Cast<IPlayer>()
                    .FirstOrDefault(
                        x => x.Position.X == this.player.Position.X && x.Position.Y == this.player.Position.Y);

            IVegetable vegetable =
                this.vegetables.Cast<Vegetable>()
                    .FirstOrDefault(
                        x => x.Position.X == this.player.Position.X && x.Position.Y == this.player.Position.Y);
        }

        private void PrintMap()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (this.player.Position.X == col && this.player.Position.Y == row)
                    {
                        continue;
                    }

                    var character = this.characters.Cast<IPlayer>().FirstOrDefault(c => c.Position.X == col &&
                                                                                        c.Position.Y == row);

                    var item =
                        this.vegetables.Cast<Vegetable>()
                            .FirstOrDefault(c => c.Position.X == col && c.Position.Y == row);
                }
            }
        }

        private void ExecuteCommand(string command)
        {

        }
    }
}