namespace HospitalDataBase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public byte[] Picture { get; set; }

        [Required]
        public bool MedicalInsurance { get; set; }

        [Required]
        public Visitation Visitation { get; set; }

        [Required]
        public Diagnose Diagnose { get; set; }

        [Required]
        public Medicament Medicament { get; set; }
    }
}