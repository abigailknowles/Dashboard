using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.PatientServices
{
    public interface IPractitionerAccountService
    {
        PractitionerAccountModel Create(PractitionerAccountModel patientModel);
        PractitionerAccountModel Delete(PractitionerAccountModel patientModel);
        PractitionerAccountModel Read(PractitionerAccountModel patientModel);
        PractitionerAccountModel Update(PractitionerAccountModel patientModel);
    }
}