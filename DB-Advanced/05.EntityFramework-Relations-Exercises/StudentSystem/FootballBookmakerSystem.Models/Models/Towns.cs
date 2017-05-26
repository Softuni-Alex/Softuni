namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;

    public class Towns
    {
        public Towns()
        {
            this.Teams = new List<Teams>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Countries Country { get; set; }

        public ICollection<Teams> Teams { get; set; }
    }
}