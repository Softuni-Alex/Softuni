namespace HospitalDataBase
{
    using Models;
    using System.Data.Entity;

    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
            : base("name= HospitalDbContext")
        {
        }

        public IDbSet<Medicament> Medicaments { get; set; }

        public IDbSet<Diagnose> Diagnoses { get; set; }

        public IDbSet<Visitation> Visitations { get; set; }

        public IDbSet<Patient> Patients { get; set; }

        public IDbSet<Doctor> Doctors { get; set; }
    }
}