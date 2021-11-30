using System.Linq;
using PatientWarningApp.Api.PractitionerAccount.Entities;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Api.PractitionerAccount
{
    public class PractitionerAccountRepository: IPractitionerAccountRepository
    {
        private readonly AppDbContext _context;

        public PractitionerAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public PractitionerAccountEntity Create(PractitionerAccountEntity entity)
        {
            var result = _context.PractitionerAccounts.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public PractitionerAccountEntity Delete(PractitionerAccountEntity entity)
        {
            var result = _context.PractitionerAccounts.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PractitionerAccountEntity Read(int id)
        {
            return _context.PractitionerAccounts.Find(id);
        }

        public PractitionerAccountEntity Update(PractitionerAccountEntity entity)
        {
            var result = _context.PractitionerAccounts.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<PractitionerAccountEntity> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
        public PractitionerAccountEntity ReadByUsernameAndPassword(PractitionerAccountEntity entity)
        {
            return _context.PractitionerAccounts.FirstOrDefault(o => o.Username == entity.Username && o.Password == entity.Password);
        }
    }
}
