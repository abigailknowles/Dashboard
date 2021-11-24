using PatientWarningApp.Services.Models;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
{
    public interface IPractitionerService
    {
        PractitionerModel Create(PractitionerModel model);
        PractitionerModel Delete(PractitionerModel model);
        PractitionerModel Read(int id);
        PractitionerModel Update(PractitionerModel model);
        List<PractitionerModel> ReadAll();
    }
}