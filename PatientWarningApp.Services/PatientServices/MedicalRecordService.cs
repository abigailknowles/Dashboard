using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using System;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
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
