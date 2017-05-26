namespace MassDefect.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SolarSystems
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}