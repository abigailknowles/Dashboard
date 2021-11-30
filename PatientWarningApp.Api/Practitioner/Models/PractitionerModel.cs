using PatientWarningApp.Api.Shared.Models;

namespace PatientWarningApp.Api.Practitioner.Models
{
    public class PractitionerModel : UserModel
    {
        public int PractitionerId { get; set; }
    }
}
