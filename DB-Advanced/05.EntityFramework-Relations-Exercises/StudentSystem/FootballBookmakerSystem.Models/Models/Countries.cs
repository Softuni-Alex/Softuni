namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Countries
    {
        public Countries()
        {
            this.Towns = new List<Towns>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Continents> Continent { get; set; }

        public ICollection<Towns> Towns { get; set; }
    }
}