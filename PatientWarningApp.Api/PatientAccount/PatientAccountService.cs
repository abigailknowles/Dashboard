using System.Collections.Generic;
using System.Linq;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.PatientAccount.Models;

namespace PatientWarningApp.Api.PatientAccount
{
    public class PatientAccountService : IPatientAccountService
    {
        private readonly IPatientAccountRepository _patientAccountRepository;

        public PatientAccountService(IPatientAccountRepository patientAccountRepository)
        {
            _patientAccountRepository = patientAccountRepository;
        }

        public PatientAccountModel Create(PatientAccountModel model)
        {
            var result = _patientAccountRepository.Create(model.ToEntity());
            return result.ToModel();
        }

        public PatientAccountModel Delete(PatientAccountModel model)
        {
            var result = _patientAccountRepository.Delete(model.ToEntity());
            return result.ToModel();
        }

        public PatientAccountModel Read(int id)
        {
            var result = _patientAccountRepository.Read(id);
            return result.ToModel();
        }

        public PatientAccountModel Update(PatientAccountModel model)
        {
            var result = _patientAccountRepository.Update(model.ToEntity());
            return result.ToModel();
        }

        public List<PatientAccountModel> ReadAll()
        {
            return _patientAccountRepository.ReadAll().Select(o => o.ToModel()).ToList();
        }

        public PatientAccountModel ReadByUsernameAndPassword(PatientAccountModel model)
        {
            var result = _patientAccountRepository.ReadByUsernameAndPassword(model.ToEntity());
            return result.ToModel();
        }
    }
}
