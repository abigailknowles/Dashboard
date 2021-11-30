using System.Linq;
using PatientWarningApp.Api.Patient.Entities;
using PatientWarningApp.Api.Patient.Interfaces;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Api.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public PatientEntity Create(PatientEntity entity)
        {
            var result = _context.Patients.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public PatientEntity Delete(PatientEntity entity)
        {
            var result = _context.Patients.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PatientEntity Read(int id)
        {
            return _context.Patients.Find(id);
        }

        public PatientEntity Update(PatientEntity entity)
        {
            var result = _context.Patients.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<PatientEntity> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }
}
