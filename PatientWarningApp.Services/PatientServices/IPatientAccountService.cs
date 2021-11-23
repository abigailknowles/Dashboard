using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.PatientServices
{
    public interface IPatientAccountService
    {
        PatientAccountModel Create(PatientAccountModel model);
        PatientAccountModel Delete(PatientAccountModel model);
        PatientAccountModel Read(int id);
        PatientAccountModel Update(PatientAccountModel model);
    }
}