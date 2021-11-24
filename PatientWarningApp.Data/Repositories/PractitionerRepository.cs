using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using System.Linq;

namespace PatientWarningApp.Data.Repositories
{
    public class PractitionerRepository: IPractitionerRepository
    {
        private readonly AppDbContext _context;

        public PractitionerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Practitioner Create(Practitioner entity)
        {
            return _context.Practitioner.Add(entity).Entity;
        }

        public Practitioner Delete(Practitioner entity)
        {
            var result = _context.Practitioner.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public Practitioner Read(int id)
        {
            return _context.Practitioner.Find(id);
        }

        public Practitioner Update(Practitioner entity)
        {
            var result = _context.Practitioner.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<Practitioner> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }

    public interface IPractitionerRepository : Repository<Practitioner>
    {
    }
}
