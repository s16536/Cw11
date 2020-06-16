using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab11.Models
{
    public class DoctorsDbContext : DbContext
    {

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public DoctorsDbContext() {}

        public DoctorsDbContext(DbContextOptions options): base(options) {}

        public virtual ICollection<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription});
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(bc => bc.IdMedicament);
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdPrescription);
        }

    }
}
