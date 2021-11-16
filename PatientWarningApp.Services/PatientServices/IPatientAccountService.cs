using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services
{
    public interface IPatientAccountService
    {
        PatientAccountModel Create(PatientAccountModel model);
        PatientAccountModel Delete(PatientAccountModel model);
        PatientAccountModel Read(PatientAccountModel model);
        PatientAccountModel Update(PatientAccountModel model);
    }
}