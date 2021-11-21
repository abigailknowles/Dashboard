using Microsoft.EntityFrameworkCore;
using PatientWarningApp.Data.Entities;
using System.Collections.Generic;

namespace PatientWarningApp.Data.Extensions
{
    public static class ModelBuilderExtension 
    {
        public static void SeedPatients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientAccount>().HasData(
                new PatientAccount
                {
                    Id = 1,
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
                    Email = "Patient1@example.com",
                    IsAdmin = false,
                    Password = "changeMe",
                    Username = "Username"
                }
            );
        }

        public static void SeedPractitioners(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<PractitionerAccount>().HasData(
                new PractitionerAccount
                {
                    Id = 1,
                    Username = "richardsi",
                    Password = "richardsi",
                    IsAdmin = true,
                    Email = "richardsi@example.com"
                }
            );
        }

        public static void SetEntityMappings(this ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<PractitionerAccount>().ToTable("PractitionerAccounts");
            modelBuilder.Entity<PatientAccount>().ToTable("PatientAccounts");

            // Configure Primary Keys  
            modelBuilder.Entity<PractitionerAccount>().HasKey(ug => ug.Id).HasName("PK_Accounts");
            modelBuilder.Entity<PatientAccount>().HasKey(ug => ug.Id).HasName("PK_Accounts");

            // Configure Forgien Keys
            // 
            modelBuilder.Entity<PatientAccount>()
            .Property<int>("PractitionerId");

            modelBuilder.Entity<PatientAccount>().HasOne(o => o.Practitioner).WithMany(o => o.PatientAccounts).HasForeignKey("PractitionerId");

            // Configure indexes  
            modelBuilder.Entity<PractitionerAccount>().HasIndex(p => p.Username).IsUnique().HasDatabaseName("Idx_Username");
            modelBuilder.Entity<PatientAccount>().HasIndex(p => p.Username).IsUnique().HasDatabaseName("Idx_Username");

            // Configure columns  
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Email).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Password).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.Username).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PractitionerAccount>().Property(ug => ug.IsAdmin).HasColumnType("tinyint").IsRequired();

            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Email).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Password).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.Username).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PatientAccount>().Property(ug => ug.IsAdmin).HasColumnType("tinyint").IsRequired();
        }
    }
}
