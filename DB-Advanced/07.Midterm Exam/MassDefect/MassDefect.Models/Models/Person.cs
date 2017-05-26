namespace MassDefect.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public Person()
        {
            this.Anomaly = new List<Anomalies>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Planets HomePlanet { get; set; }

        public ICollection<Anomalies> Anomaly { get; set; }
    }
}