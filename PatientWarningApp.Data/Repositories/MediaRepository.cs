using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using System.Linq;

namespace PatientWarningApp.Data.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly AppDbContext _context;

        public MediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public Media Create(Media entity)
        {
            return _context.Media.Add(entity).Entity;
        }

        public Media Delete(Media entity)
        {
            var result = _context.Media.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public Media Read(int id)
        {
            return _context.Media.Find(id);
        }

        public Media Update(Media entity)
        {
            var result = _context.Media.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<Media> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }

    public interface IMediaRepository : Repository<Media>
    {
    }
}
