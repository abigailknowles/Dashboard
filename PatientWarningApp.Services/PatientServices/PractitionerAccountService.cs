using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using System;

namespace PatientWarningApp.Services.PatientServices
{
    public class PractitionerAccountService : IPractitionerAccountService
    {
        private readonly IPractitionerAccountRepository _practitionerAccountRepository;

        public PractitionerAccountService(IPractitionerAccountRepository practitionerAccountRepository)
        {
            _practitionerAccountRepository = practitionerAccountRepository;
        }

        public PractitionerAccountModel Create(PractitionerAccountModel model)
        {
            var result = _practitionerAccountRepository.Create(model.ToEntity());
            return result.ToModel();
        }

        public PractitionerAccountModel Delete(PractitionerAccountModel model)
        {
            var result = _practitionerAccountRepository.Delete(model.ToEntity());
            return result.ToModel();
        }

        public PractitionerAccountModel Read(int id)
        {
            var result = _practitionerAccountRepository.Read(id);
            return result.ToModel();
        }

        public PractitionerAccountModel Update(PractitionerAccountModel model)
        {
            var result = _practitionerAccountRepository.Update(model.ToEntity());
            return result.ToModel();
        }

        public PractitionerAccountModel ReadByUsernameAndPassword(PractitionerAccountModel model)
        {
            var result = _practitionerAccountRepository.ReadByUsernameAndPassword(model.ToEntity());
            return result.ToModel();
        }
    }
}
