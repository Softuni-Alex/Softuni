namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;

    public class Continents
    {
        public Continents()
        {
            this.Countries = new List<Countries>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}