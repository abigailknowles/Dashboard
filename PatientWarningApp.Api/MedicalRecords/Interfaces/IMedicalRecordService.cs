using PatientWarningApp.Api.MedicalRecords.Models;

namespace PatientWarningApp.Api.MedicalRecords.Interfaces
{
    public interface IMedicalRecordService
    {
        MedicalRecordModel Create(MedicalRecordModel model);
        MedicalRecordModel Delete(MedicalRecordModel model);
        MedicalRecordModel Read(int id);
        MedicalRecordModel Update(MedicalRecordModel model);
    }
}