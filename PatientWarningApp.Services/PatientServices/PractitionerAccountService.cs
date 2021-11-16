using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using System;

namespace PatientWarningApp.Services.PatientServices
{
    public class PractitionerAccountService : IPractitionerAccountService
    {
        private readonly IPractitionerAccountRepository _practitionerAccountRepository;
        private readonly IPractitionerAccountMapper _practitionerAccountMapper;

        public PractitionerAccountService(IPractitionerAccountRepository practitionerAccountRepository, IPractitionerAccountMapper practitionerAccountMapper)
        {
            _practitionerAccountRepository = practitionerAccountRepository;
            _practitionerAccountMapper = practitionerAccountMapper;
        }

        public PractitionerAccountModel Create(PractitionerAccountModel model)
        {
            var entity = _practitionerAccountMapper.ToEntity(model);
            var result = _practitionerAccountRepository.Create(entity);
            return _practitionerAccountMapper.ToModel(result);
        }

        public PractitionerAccountModel Delete(PractitionerAccountModel model)
        {
            var entity = _practitionerAccountMapper.ToEntity(model);
            var result = _practitionerAccountRepository.Delete(entity);
            return _practitionerAccountMapper.ToModel(result);
        }

        public PractitionerAccountModel Read(PractitionerAccountModel model)
        {
            var entity = _practitionerAccountMapper.ToEntity(model);
            var result = _practitionerAccountRepository.Read(entity);
            return _practitionerAccountMapper.ToModel(result);
        }

        public PractitionerAccountModel Update(PractitionerAccountModel model)
        {
            var entity = _practitionerAccountMapper.ToEntity(model);
            var result = _practitionerAccountRepository.Update(entity);
            return _practitionerAccountMapper.ToModel(result);
        }
    }
}
