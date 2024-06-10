using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Data;

public class ApplicationContext:DbContext

{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament>PrescriptionMedicaments { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new (){IdDoctor = 1,Email="cc11@gmail.com",FirstName = "Joe",LastName = "Bart"},
            new (){IdDoctor =2 ,Email = "2@gmail.com",FirstName = "Cezar",LastName = "Czosnek"}
        });
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new() { Birthdate = new DateTime(2000, 12, 12), FirstName = "Fiodar", LastName = "Piatrou", IdPatient = 1 },
            new() { IdPatient = 2, FirstName = "Lol", LastName = "Kekowski", Birthdate = new DateTime(1999, 1, 1) }
        });
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new()
            {
                IdDoctor = 1,IdPatient = 1,IdPrescription = 1,Date = new DateTime(2003,10,10),
                DueDate = new DateTime(2024,12,12)
            }
        });
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new()
            {
                IdMedication = 1,
                IdPrescription = 1,
                Details = "some details",
                Dose = 1
            }
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament()
            {
                Description = "Lethal",
                IdMedicament = 1,
                Name = "Welbox"
            }
        });

    }
}