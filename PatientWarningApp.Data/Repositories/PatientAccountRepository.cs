using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using System.Linq;

namespace PatientWarningApp.Data.Repositories
{
    public class PatientAccountRepository : IPatientAccountRepository
    {
        private readonly AppDbContext _context;

        public PatientAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public PatientAccount Create(PatientAccount entity)
        {
            return _context.PatientAccounts.Add(entity).Entity;
        }

        public PatientAccount Delete(PatientAccount entity)
        {
            var result = _context.PatientAccounts.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PatientAccount Read(int id)
        {
            return _context.PatientAccounts.Find(id);
        }

        public PatientAccount Update(PatientAccount entity)
        {
            var result = _context.PatientAccounts.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<PatientAccount> ReadAll()
        {
            return _context.PatientAccounts.AsQueryable();
        }

    }

    public interface IPatientAccountRepository : Repository<PatientAccount>
    {
    }
}
