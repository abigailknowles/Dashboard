using Microsoft.EntityFrameworkCore;
using PatientWarningApp.Api.Media.Entities;
using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.Patient.Entities;
using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.Practitioner.Entities;
using PatientWarningApp.Api.PractitionerAccount.Entities;
using PatientWarningApp.Api.ReviewedMedia.Entities;
using PatientWarningApp.Api.Shared.Extensions;

namespace PatientWarningApp.Api.Shared.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<PractitionerAccountEntity> PractitionerAccounts { get; set; }
        public DbSet<PatientAccountEntity> PatientAccounts { get; set; }
        public DbSet<PractitionerEntity> Practitioners { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<MediaEntity> Media { get; set; }
        public DbSet<ReviewedMediaEntity> ReviewedMedia { get; set; }
        public DbSet<MedicalRecordEntity> MedicalRecords { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetEntityMappings();
           modelBuilder.SeedPatientAccounts();
           modelBuilder.SeedPractitionerAccounts();
        }
    }
}
