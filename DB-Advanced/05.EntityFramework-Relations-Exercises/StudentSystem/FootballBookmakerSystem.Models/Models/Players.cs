namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;

    public class Players
    {
        public Players()
        {
            this.Games = new List<Games>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public Teams Team { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<Games> Games { get; set; }

        public ICollection<PlayerStatistics> PlayerStatisticses { get; set; }
    }
}