using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.PatientServices
{
    public class PatientAccountService : IPatientAccountService
    {
        private readonly IPatientAccountRepository _patientAccountRepository;
        private readonly IPatientAccountMapper _patientAccountMapper;

        public PatientAccountService(IPatientAccountRepository patientAccountRepository, IPatientAccountMapper patientAccountMapper)
        {
            _patientAccountRepository = patientAccountRepository;
            _patientAccountMapper = patientAccountMapper;
        }

        public PatientAccountModel Create(PatientAccountModel model)
        {
            var entity = _patientAccountMapper.ToEntity(model);
            var result = _patientAccountRepository.Create(entity);
            return _patientAccountMapper.ToModel(result);
        }

        public PatientAccountModel Delete(PatientAccountModel model)
        {
            var entity = _patientAccountMapper.ToEntity(model);
            var result = _patientAccountRepository.Delete(entity);
            return _patientAccountMapper.ToModel(result);
        }

        public PatientAccountModel Read(int id)
        {
            var result = _patientAccountRepository.Read(id);
            return _patientAccountMapper.ToModel(result);
        }

        public PatientAccountModel Update(PatientAccountModel model)
        {
            var entity = _patientAccountMapper.ToEntity(model);
            var result = _patientAccountRepository.Update(entity);
            return _patientAccountMapper.ToModel(result);
        }
    }
}
