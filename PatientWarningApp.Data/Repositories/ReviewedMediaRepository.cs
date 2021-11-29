using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using System.Linq;

namespace PatientWarningApp.Data.Repositories
{
    public class ReviewedMediaRepository : IReviewedMediaRepository
    {
        private readonly AppDbContext _context;

        public ReviewedMediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public ReviewedMedia Create(ReviewedMedia entity)
        {
            return _context.ReviewedMedia.Add(entity).Entity;
        }

        public ReviewedMedia Delete(ReviewedMedia entity)
        {
            var result = _context.ReviewedMedia.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public ReviewedMedia Read(int id)
        {
            return _context.ReviewedMedia.Find(id);
        }

        public ReviewedMedia Update(ReviewedMedia entity)
        {
            var result = _context.ReviewedMedia.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<ReviewedMedia> ReadAll()
        {
            throw new System.NotImplementedException();
        }
        
    }

    public interface IReviewedMediaRepository : Repository<ReviewedMedia>
    {
    }
}
