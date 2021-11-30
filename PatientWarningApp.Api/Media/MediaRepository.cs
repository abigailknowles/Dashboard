using System.Linq;
using PatientWarningApp.Api.Media.Entities;
using PatientWarningApp.Api.Media.Interfaces;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Api.Media
{
    public class MediaRepository : IMediaRepository
    {
        private readonly AppDbContext _context;

        public MediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public MediaEntity Create(MediaEntity entity)
        {
            var result = _context.Media.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public MediaEntity Delete(MediaEntity entity)
        {
            var result = _context.Media.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public MediaEntity Read(int id)
        {
            return _context.Media.Find(id);
        }

        public MediaEntity Update(MediaEntity entity)
        {
            var result = _context.Media.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<MediaEntity> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }
}
