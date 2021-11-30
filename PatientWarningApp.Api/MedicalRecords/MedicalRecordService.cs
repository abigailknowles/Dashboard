using PatientWarningApp.Api.MedicalRecords.Interfaces;
using PatientWarningApp.Api.MedicalRecords.Models;

namespace PatientWarningApp.Api.MedicalRecords
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecordModel Create(MedicalRecordModel model)
        {
            var result = _medicalRecordRepository.Create(model.ToEntity());
            return result.ToModel();
        }

        public MedicalRecordModel Delete(MedicalRecordModel model)
        {
            var result = _medicalRecordRepository.Delete(model.ToEntity());
            return result.ToModel();
        }

        public MedicalRecordModel Read(int id)
        {
            var result = _medicalRecordRepository.Read(id);
            return result.ToModel();
        }

        public MedicalRecordModel Update(MedicalRecordModel model)
        {
            var result = _medicalRecordRepository.Update(model.ToEntity());
            return result.ToModel();
        }
    }
}
