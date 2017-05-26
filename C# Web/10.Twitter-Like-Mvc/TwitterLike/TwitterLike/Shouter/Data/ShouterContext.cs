using Shouter.Models;

namespace Shouter.Data
{
    using System.Data.Entity;

    public class ShouterContext : DbContext
    {
        public ShouterContext()
            : base("name=ShouterContext")
        {
        }

        public virtual DbSet<Register> Register { get; set; }

        //        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<Register>()
        //                .Property(r => r.Username)
        //                .IsRequired()
        //                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        //                    new IndexAnnotation(
        //                        new IndexAttribute("IX_Username", 1) { IsUnique = true }));
        //
        //            modelBuilder.Entity<Register>()
        //               .Property(r => r.Email)
        //               .IsRequired()
        //               .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        //                   new IndexAnnotation(
        //                       new IndexAttribute("IX_Email", 1) { IsUnique = true }));
        //        }
    }
}