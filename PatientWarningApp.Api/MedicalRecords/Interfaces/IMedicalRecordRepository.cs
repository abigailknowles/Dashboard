using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.Shared.Repositories;

namespace PatientWarningApp.Api.MedicalRecords.Interfaces
{
    public interface IMedicalRecordRepository : Repository<MedicalRecordEntity>
    {
    }
}