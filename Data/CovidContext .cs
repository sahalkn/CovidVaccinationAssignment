using CovidVaccinationPatientDetailsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidVaccinationPatientDetailsSystem.Data
{
    public class CovidContext : DbContext
    {
        public CovidContext(DbContextOptions<CovidContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Vaccination)
                .WithMany()
                .HasForeignKey(p => p.VaccinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
