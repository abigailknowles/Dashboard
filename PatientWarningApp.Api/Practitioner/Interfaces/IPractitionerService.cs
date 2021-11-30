using System.Collections.Generic;
using PatientWarningApp.Api.Practitioner.Models;

namespace PatientWarningApp.Api.Practitioner.Interfaces
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