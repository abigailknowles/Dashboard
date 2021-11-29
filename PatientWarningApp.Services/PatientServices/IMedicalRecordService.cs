using PatientWarningApp.Services.Models;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
{
    public interface IMedicalRecordService
    {
        MedicalRecordModel Create(MedicalRecordModel model);
        MedicalRecordModel Delete(MedicalRecordModel model);
        MedicalRecordModel Read(int id);
        MedicalRecordModel Update(MedicalRecordModel model);
    }
}