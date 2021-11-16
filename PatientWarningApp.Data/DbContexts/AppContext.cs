using Microsoft.EntityFrameworkCore;
using PatientWarningApp.Data.Entities;

namespace PatientWarningApp.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<PractitionerAccount> PractitionerAccounts { get; set; }
        public DbSet<PatientAccount> PatientAccounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<PractitionerAccount>().ToTable("PractitionerAccounts");
            modelBuilder.Entity<PatientAccount>().ToTable("PatientAccounts");

            // Configure Primary Keys  
            modelBuilder.Entity<PractitionerAccount>().HasKey(ug => ug.Id).HasName("PK_Accounts");
            modelBuilder.Entity<PatientAccount>().HasKey(ug => ug.Id).HasName("PK_Accounts");

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
    }
}
