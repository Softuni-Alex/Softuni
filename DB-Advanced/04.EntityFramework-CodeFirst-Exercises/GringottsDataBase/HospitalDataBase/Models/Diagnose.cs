namespace HospitalDataBase.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Diagnose
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}