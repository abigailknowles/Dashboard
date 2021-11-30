using System.Linq;
using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.MedicalRecords.Interfaces;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Api.MedicalRecords
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly AppDbContext _context;

        public MedicalRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public MedicalRecordEntity Create(MedicalRecordEntity entity)
        {
            var result = _context.MedicalRecords.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public MedicalRecordEntity Delete(MedicalRecordEntity entity)
        {
            var result = _context.MedicalRecords.Remove(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public MedicalRecordEntity Read(int id)
        {
            return _context.MedicalRecords.Find(id);
        }

        public MedicalRecordEntity Update(MedicalRecordEntity entity)
        {
            var result = _context.MedicalRecords.Update(entity).Entity;
            _context.SaveChanges();

            return result;
        }

        public IQueryable<MedicalRecordEntity> ReadAll()
        {
            return _context.MedicalRecords.AsQueryable();
        }

    }
}
