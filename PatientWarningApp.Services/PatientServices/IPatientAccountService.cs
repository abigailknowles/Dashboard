using PatientWarningApp.Services.Models;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
{
    public interface IPatientAccountService
    {
        PatientAccountModel Create(PatientAccountModel model);
        PatientAccountModel Delete(PatientAccountModel model);
        PatientAccountModel Read(int id);
        PatientAccountModel Update(PatientAccountModel model);
        List<PatientAccountModel> ReadAll();
    }
}