namespace MassDefect.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Anomalies
    {
        public Anomalies()
        {
            this.Person = new List<Person>();
        }

        public int Id { get; set; }

        [InverseProperty("OriginAnomalies")]
        public Planets OriginPlanet { get; set; }

        [InverseProperty("TeleportAnomalies")]
        public Planets TeleportPlanet { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}