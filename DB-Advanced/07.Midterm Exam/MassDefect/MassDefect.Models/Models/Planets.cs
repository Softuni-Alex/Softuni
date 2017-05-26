using System.Collections.Generic;

namespace MassDefect.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Planets
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //        [Column("SunId")]
        public Stars Sun { get; set; }

        //        [Column("SolarSystemId")]
        public SolarSystems SolarSystem { get; set; }

        public ICollection<Anomalies> OriginAnomalies { get; set; }

        public ICollection<Anomalies> TeleportAnomalies { get; set; }
    }
}