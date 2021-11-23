using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.PatientServices
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