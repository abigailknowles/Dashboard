using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Api.PractitionerAccount.Interfaces
{
    public interface IPractitionerAccountService
    {
        PractitionerAccountModel Create(PractitionerAccountModel patientModel);
        PractitionerAccountModel Delete(PractitionerAccountModel patientModel);
        PractitionerAccountModel Read(int id);
        PractitionerAccountModel Update(PractitionerAccountModel patientModel);
        PractitionerAccountModel ReadByUsernameAndPassword(PractitionerAccountModel model);
    }
}