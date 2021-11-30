using System.Linq;
using PatientWarningApp.Api.ReviewedMedia.Entities;
using PatientWarningApp.Api.Shared.Contexts;
using PatientWarningApp.Api.Shared.Repositories;

namespace PatientWarningApp.Api.ReviewedMedia
{
    public class ReviewedMediaRepository : IReviewedMediaRepository
    {
        private readonly AppDbContext _context;

        public ReviewedMediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public ReviewedMediaEntity Create(ReviewedMediaEntity entity)
        {
            var result = _context.ReviewedMedia.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public ReviewedMediaEntity Delete(ReviewedMediaEntity entity)
        {
            var result = _context.ReviewedMedia.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public ReviewedMediaEntity Read(int id)
        {
            return _context.ReviewedMedia.Find(id);
        }

        public ReviewedMediaEntity Update(ReviewedMediaEntity entity)
        {
            var result = _context.ReviewedMedia.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<ReviewedMediaEntity> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }

    public interface IReviewedMediaRepository : Repository<ReviewedMediaEntity>
    {
    }
}
