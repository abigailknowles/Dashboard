using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;
using System.Linq;

namespace PatientWarningApp.Data.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly AppDbContext _context;

        public MedicalRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public MedicalRecord Create(MedicalRecord entity)
        {
            return _context.MedicalRecords.Add(entity).Entity;
        }

        public MedicalRecord Delete(MedicalRecord entity)
        {
            var result = _context.MedicalRecords.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public MedicalRecord Read(int id)
        {
            return _context.MedicalRecords.Find(id);
        }

        public MedicalRecord Update(MedicalRecord entity)
        {
            var result = _context.MedicalRecords.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<MedicalRecord> ReadAll()
        {
            return _context.MedicalRecords.AsQueryable();
        }

    }

    public interface IMedicalRecordRepository : Repository<MedicalRecord>
    {
    }
}
