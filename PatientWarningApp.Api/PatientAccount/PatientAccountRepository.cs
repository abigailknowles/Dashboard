using System.Linq;
using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Api.PatientAccount
{
    public class PatientAccountRepository : IPatientAccountRepository
    {
        private readonly AppDbContext _context;

        public PatientAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public PatientAccountEntity Create(PatientAccountEntity entity)
        {
            var result = _context.PatientAccounts.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public PatientAccountEntity Delete(PatientAccountEntity entity)
        {
            var result = _context.PatientAccounts.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PatientAccountEntity Read(int id)
        {
            return _context.PatientAccounts.Find(id);
        }

        public PatientAccountEntity Update(PatientAccountEntity entity)
        {
            var result = _context.PatientAccounts.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<PatientAccountEntity> ReadAll()
        {
            return _context.PatientAccounts.AsQueryable();
        }
        public PatientAccountEntity ReadByUsernameAndPassword(PatientAccountEntity entity)
        {
            return _context.PatientAccounts.FirstOrDefault(o => o.Username == entity.Username && o.Password == entity.Password);
        }
    }
}
