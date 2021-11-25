using PatientWarningApp.Services.Models;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
{
    public interface IPatientService
    {
        PatientModel Create(PatientModel model);
        PatientModel Delete(PatientModel model);
        PatientModel Read(int id);
        PatientModel Update(PatientModel model);
        List<PatientModel> ReadAll();
    }
}