using Microsoft.EntityFrameworkCore;
using PaternLab.Models;

namespace PaternLab.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Examination> Examination { get; set; }
        public DbSet<HealthySystem> HealthySystem { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientExamination> PatientExamination { get; set; }
        public DbSet<Symptom> Symptom { get; set; }
        public DbSet<CsvData> CsvData { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Symptom>()
                .HasOne(s => s.Patient)
                .WithMany(p => p.symptoms)
                .HasForeignKey(s => s.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
        }



    }
}
