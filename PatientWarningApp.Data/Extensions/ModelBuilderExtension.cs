using Microsoft.EntityFrameworkCore;
using PatientWarningApp.Data.Entities;
using System.Collections.Generic;

namespace PatientWarningApp.Data.Extensions
{
    public static class ModelBuilderExtension 
    {
        public static void SeedPatientAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientAccount>().HasData(
                new PatientAccount
                {
                    Id = 1,
                    PatientAccountId = 1,
                    PractitionerAccountId = 1,
                    Email = "Patient1@example.com",
                    IsAdmin = false,
                    Password = "changeMe",
                    Username = "Username"
                }
            );

            modelBuilder.Entity<PatientAccount>().HasData(
                new PatientAccount
                {
                    Id = 2,
                    PatientAccountId = 2,
                    Email = "Patient1@example.com",
                    IsAdmin = false,
                    Password = "changeMe",
                    Username = "Username"
                }
            );
        }

        public static void SeedPractitionerAccounts(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<PractitionerAccount>().HasData(
                new PractitionerAccount
                {
                    Id = 1,
                    PractitionerAccountId = 1,
                    Username = "abigail",
                    Password = "password",
                    IsAdmin = true,
                    Email = "richardsi@example.com"
                }
            );
        }

        public static void SeedPractitioners(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Practitioner>().HasData(
                new Practitioner
                {
                    Id = 1,
                    PractitionerId = 1,
                    FirstName = "Abigail",
                    LastName = "Knowles",
                    Gender = "Female",
                    DOB = "08/08/2000",
                    MobileNumber = "1234567890",
                    Title = "Miss"
                }
            );
        }


        public static void SeedPatients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    PatientId = 1,
                    FirstName = "Abigail",
                    LastName = "Knowles",
                    Gender = "Female",
                    DOB = "08/08/2000",
                    MobileNumber = "1234567890",
                    Title = "Miss"
                }
            );
        }

        public static void SetEntityMappings(this ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<PractitionerAccount>().ToTable("PractitionerAccounts");
            modelBuilder.Entity<PatientAccount>().ToTable("PatientAccounts");
            modelBuilder.Entity<Practitioner>().ToTable("Practitioners");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Media>().ToTable("Media");
            modelBuilder.Entity<ReviewedMedia>().ToTable("ReviewedMedia");

            // Configure Primary Keys  
            modelBuilder.Entity<PractitionerAccount>().HasKey(ug => ug.PractitionerAccountId).HasName("PK_PractitionerAccounts");
            modelBuilder.Entity<PatientAccount>().HasKey(ug => ug.PatientAccountId).HasName("PK_PatientAccounts");
            modelBuilder.Entity<Practitioner>().HasKey(ug => ug.PractitionerId).HasName("PK_Practitioners");
            modelBuilder.Entity<Patient>().HasKey(ug => ug.PatientId).HasName("PK_Patients");
            modelBuilder.Entity<Media>().HasKey(ug => ug.Id).HasName("PK_Media");
            modelBuilder.Entity<ReviewedMedia>().HasKey(ug => ug.Id).HasName("PK_ReviewedMedia");

            // Configure Forgien Keys


            // Configure indexes 
            modelBuilder.Entity<Practitioner>().HasIndex(p => p.FirstName).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<Practitioner>().HasIndex(p => p.LastName).HasDatabaseName("Idx_LastName");

            // Configure columns  
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.PractitionerAccountId).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Email).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Password).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Username).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.IsAdmin).HasColumnType("tinyint").IsRequired();

            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Email).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Password).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Username).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.IsAdmin).HasColumnType("tinyint").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.PatientAccountId).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            modelBuilder.Entity<Practitioner>().Property(ug => ug.PractitionerId).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Practitioner>().Property(ug => ug.Title).HasColumnType("nvarchar(20)").IsRequired();
            modelBuilder.Entity<Practitioner>().Property(ug => ug.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Practitioner>().Property(ug => ug.LastName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Practitioner>().Property(ug => ug.MobileNumber).HasColumnType("nvarchar(13)").IsRequired();
            modelBuilder.Entity<Practitioner>().Property(ug => ug.DOB).HasColumnType("nvarchar(10)").IsRequired();
            modelBuilder.Entity<Practitioner>().Property(ug => ug.Gender).HasColumnType("nvarchar(30)").IsRequired();

            modelBuilder.Entity<Patient>().Property(ug => ug.PatientId).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Patient>().Property(ug => ug.Title).HasColumnType("nvarchar(20)").IsRequired();
            modelBuilder.Entity<Patient>().Property(ug => ug.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Patient>().Property(ug => ug.LastName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Patient>().Property(ug => ug.MobileNumber).HasColumnType("nvarchar(13)").IsRequired();
            modelBuilder.Entity<Patient>().Property(ug => ug.DOB).HasColumnType("nvarchar(10)").IsRequired();
            modelBuilder.Entity<Patient>().Property(ug => ug.Gender).HasColumnType("nvarchar(30)").IsRequired();

            modelBuilder.Entity<Media>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Media>().Property(ug => ug.Title).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Media>().Property(ug => ug.Genre).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Media>().Property(ug => ug.Director).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Media>().Property(ug => ug.ReleaseDate).HasColumnType("nvarchar(200)").IsRequired();

            modelBuilder.Entity<ReviewedMedia>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<ReviewedMedia>().Property(ug => ug.EpilepsyRating).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<ReviewedMedia>().Property(ug => ug.SeizureTriggerTimes).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<ReviewedMedia>().Property(ug => ug.Notes).HasColumnType("nvarchar(200)").IsRequired();

        }
    }
}
