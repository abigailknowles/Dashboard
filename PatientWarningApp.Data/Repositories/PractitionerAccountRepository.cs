using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;

namespace PatientWarningApp.Data.Repositories
{
    public class PractitionerAccountRepository: IPractitionerAccountRepository
    {
        private readonly AppDbContext _context;

        public PractitionerAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public PractitionerAccount Create(PractitionerAccount entity)
        {
            return _context.PractitionerAccounts.Add(entity).Entity;
        }

        public PractitionerAccount Delete(PractitionerAccount entity)
        {
            var result = _context.PractitionerAccounts.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PractitionerAccount Read(PractitionerAccount entity)
        {
            return _context.PractitionerAccounts.Find(entity.Id);
        }

        public PractitionerAccount Update(PractitionerAccount entity)
        {
            var result = _context.PractitionerAccounts.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }
    }

    public interface IPractitionerAccountRepository : Repository<PractitionerAccount>
    {
    }
}
