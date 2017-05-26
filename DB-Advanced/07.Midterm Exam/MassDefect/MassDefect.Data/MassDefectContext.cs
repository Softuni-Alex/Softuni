using System.Data.Entity;

namespace MassDefect.Data
{
    using Models.Models;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("MassDefectContext")
        {
            this.Database.Initialize(true);
        }

        public IDbSet<Anomalies> Anomalies { get; set; }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Planets> Planets { get; set; }

        public IDbSet<SolarSystems> SolarSystems { get; set; }

        public IDbSet<Stars> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomalies>()
                .HasMany(t => t.Person)
                .WithMany(p => p.Anomaly)
                .Map(m =>
                {
                    m.ToTable("AnomalyVictims");
                    m.MapLeftKey("AnomalyId");
                    m.MapRightKey("PersonId");
                });
        }
    }
}