using System.Linq;
using PatientWarningApp.Api.Practitioner.Entities;
using PatientWarningApp.Api.Practitioner.Interfaces;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Api.Practitioner
{
    public class PractitionerRepository: IPractitionerRepository
    {
        private readonly AppDbContext _context;

        public PractitionerRepository(AppDbContext context)
        {
            _context = context;
        }

        public PractitionerEntity Create(PractitionerEntity entity)
        {
            var result = _context.Practitioners.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public PractitionerEntity Delete(PractitionerEntity entity)
        {
            var result = _context.Practitioners.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public PractitionerEntity Read(int id)
        {
            return _context.Practitioners.Find(id);
        }

        public PractitionerEntity Update(PractitionerEntity entity)
        {
            var result = _context.Practitioners.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<PractitionerEntity> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }
}
