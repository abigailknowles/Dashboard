using System.Collections.Generic;
using PatientWarningApp.Api.Patient.Models;

namespace PatientWarningApp.Api.Patient.Interfaces
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