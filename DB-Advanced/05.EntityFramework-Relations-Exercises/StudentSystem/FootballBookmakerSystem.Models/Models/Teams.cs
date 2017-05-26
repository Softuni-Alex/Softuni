namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Teams
    {
        public Teams()
        {
            this.Players = new List<Players>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        [MaxLength(3), MinLength(3)]
        public string Initials { get; set; }

        public Colors PrimaryKitColor { get; set; }

        public Colors SecondaryKitColor { get; set; }

        public decimal Budget { get; set; }

        public Towns Town { get; set; }

        public ICollection<Players> Players { get; set; }
    }
}