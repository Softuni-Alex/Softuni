namespace MassDefect.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Stars
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //        [Column("SolarSystemId")]
        public SolarSystems SolarSystem { get; set; }
    }
}