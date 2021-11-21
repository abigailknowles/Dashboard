using Microsoft.EntityFrameworkCore;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Extensions;

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
            modelBuilder.SetEntityMappings();
            modelBuilder.SeedPatients();
            modelBuilder.SeedPractitioners();
        }
    }
}
