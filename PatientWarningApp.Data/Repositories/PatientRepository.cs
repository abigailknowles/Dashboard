using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using System.Linq;

namespace PatientWarningApp.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public Patient Create(Patient entity)
        {
            return _context.Patient.Add(entity).Entity;
        }

        public Patient Delete(Patient entity)
        {
            var result = _context.Patient.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public Patient Read(int id)
        {
            return _context.Patient.Find(id);
        }

        public Patient Update(Patient entity)
        {
            var result = _context.Patient.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<Patient> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }

    public interface IPatientRepository : Repository<Patient>
    {
    }
}
