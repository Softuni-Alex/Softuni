namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Position
    {
        public Position()
        {
            this.Players = new List<Players>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string PositionDescription { get; set; }

        public ICollection<Players> Players { get; set; }
    }
}