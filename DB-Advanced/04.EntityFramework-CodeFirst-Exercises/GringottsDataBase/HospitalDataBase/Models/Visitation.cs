namespace HospitalDataBase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public Doctor Doctor { get; set; }
    }
}