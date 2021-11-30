using System.Collections.Generic;
using PatientWarningApp.Api.PatientAccount.Models;

namespace PatientWarningApp.Api.PatientAccount.Interfaces
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