using System.Linq;
using System.Collections.Generic;
using PatientWarningApp.Api.Patient.Interfaces;
using PatientWarningApp.Api.Patient.Models;

namespace PatientWarningApp.Api.Patient
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
            var patientEntitiesList = _patientRepository.ReadAll().ToList();
            var patientModelList = new List<PatientModel>();
            patientEntitiesList.ForEach(item => {
                patientModelList.Add(item.ToModel());
            });
            return patientModelList;
        }

        public PatientModel Update(PatientModel model)
        {
            var result = _patientRepository.Update(model.ToEntity());
            return result.ToModel();
        }
    }
}
