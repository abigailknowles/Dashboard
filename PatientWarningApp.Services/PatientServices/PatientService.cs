using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using System;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public PatientModel Create(PatientModel model)
        {
            var result = _patientRepository.Create(model.ToEntity());
            return result.ToModel();
        }

        public PatientModel Delete(PatientModel model)
        {
            var result = _patientRepository.Delete(model.ToEntity());
            return result.ToModel();
        }

        public PatientModel Read(int id)
        {
            var result = _patientRepository.Read(id);
            return result.ToModel();
        }

        public List<PatientModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public PatientModel Update(PatientModel model)
        {
            var result = _patientRepository.Update(model.ToEntity());
            return result.ToModel();
        }
    }
}
