using System.Linq;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Api.Interactors
{
    //TODO: Needs extending to include all use cases
    //TODO: Add Interactors for Patients
    public class PractitionerInteractor : IPractitionerInteractor
    {
        private readonly IPractitionerAccountService _practitionerService;
        private readonly IPatientAccountService _patientService;

        public PractitionerInteractor(IPractitionerAccountService practitionerService, IPatientAccountService patientService)
        {
            _practitionerService = practitionerService;
            _patientService = patientService;
        }

        public PractitionerAccountModel Read(int id)
        {
            var practitioner = _practitionerService.Read(id);
            var patients = _patientService.ReadAll();

            practitioner.PatientAccounts = patients.Where(p => p.PractitionerId == practitioner.PractitionerAccountId).ToList();

            return practitioner;
        }

        public PractitionerAccountModel AddPatientToPractitionerAccount(PractitionerAccountModel practitionerAccountModel)
        {
            practitionerAccountModel.PatientAccounts.ForEach(account =>
            {
                _patientService.Update(account);
            });

            practitionerAccountModel.PatientAccounts = null;
            practitionerAccountModel.PatientAccounts = _patientService.ReadAll().Where(o => o.PatientAccountId == practitionerAccountModel.PractitionerAccountId).ToList();
            return practitionerAccountModel;
        }

        public object Delete(PractitionerAccountModel account)
        {
            throw new System.NotImplementedException();
        }

        public object Create(PractitionerAccountModel account)
        {
            throw new System.NotImplementedException();
        }

        public object Update(PractitionerAccountModel account)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPractitionerInteractor
    {
        PractitionerAccountModel Read(int id);
        PractitionerAccountModel AddPatientToPractitionerAccount(PractitionerAccountModel practitionerAccountModel);
        object Delete(PractitionerAccountModel account);
        object Create(PractitionerAccountModel account);
        object Update(PractitionerAccountModel account);
    }
}
