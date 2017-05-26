namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;

    public class Rounds
    {
        public Rounds()
        {
            this.Games = new List<Games>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Games> Games { get; set; }
    }
}