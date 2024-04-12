using Microsoft.EntityFrameworkCore;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Nomenclador> Nomencladores { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<DroneMedication>().Property(e => e.Id).ValueGeneratedNever();

        //    modelBuilder.Entity<Drone>()
        //        .HasMany(e => e.DroneMedications)
        //        .WithOne(e => e.Drone)
        //        .HasForeignKey(e => e.DroneSerialNumber)
        //        .IsRequired();

        //    modelBuilder.Entity<Medication>()
        //        .HasMany(e => e.DroneMedications)
        //        .WithOne(e => e.Medication)
        //        .HasForeignKey(e => e.MedicationCode)
        //        .IsRequired();
        }
         
    }
}
