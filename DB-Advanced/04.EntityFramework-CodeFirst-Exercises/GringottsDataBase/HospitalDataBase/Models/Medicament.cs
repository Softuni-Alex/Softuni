namespace HospitalDataBase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}