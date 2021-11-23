using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Linq;

namespace PatientWarningApp.Api.Interactors
{
    public class PractitionerInteractor : IPractitionerInteractor
    {
        private IPractitionerAccountService _practitionerService;
        private readonly IPatientAccountService _patientService;

        public PractitionerInteractor(IPractitionerAccountService practitionerService, IPatientAccountService patientService)
        {
            _practitionerService = practitionerService;
            _patientService = patientService;
        }

        public PractitionerAccountModel AddPatientToPractitionerAccount(PractitionerAccountModel practitionerAccountModel)
        {
            practitionerAccountModel.PatientAccounts.ForEach(account =>
            {
                _patientService.Update(account);
            });

            //Ensure we have updated the database by clearing the list and repopulating with fresh data
            practitionerAccountModel.PatientAccounts = null;
            practitionerAccountModel.PatientAccounts = _patientService.ReadAll().Where(o => o.PractitionerId == practitionerAccountModel.Id).ToList();
            return practitionerAccountModel;
        }
    }

    public interface IPractitionerInteractor
    {
        PractitionerAccountModel AddPatientToPractitionerAccount(PractitionerAccountModel practitionerAccountModel);
    }
}
