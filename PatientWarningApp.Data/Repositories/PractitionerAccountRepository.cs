using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using System;
using System.Linq;

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

        public PractitionerAccount Read(int id)
        {
            return _context.PractitionerAccounts.Find(id);
        }

        public PractitionerAccount Update(PractitionerAccount entity)
        {
            var result = _context.PractitionerAccounts.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PractitionerAccount ReadByUsernameAndPassword(PractitionerAccount entity)
        {
            return _context.PractitionerAccounts.FirstOrDefault(o => o.Username == entity.Username && o.Password == entity.Password);
        }
    }

    public interface IPractitionerAccountRepository : Repository<PractitionerAccount>
    {
        PractitionerAccount ReadByUsernameAndPassword(PractitionerAccount entity);
    }
}
