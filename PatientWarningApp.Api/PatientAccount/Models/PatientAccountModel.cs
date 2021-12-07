using PatientWarningApp.Api.Shared.Models;

namespace PatientWarningApp.Api.PatientAccount.Models
{
    public class PatientAccountModel : AccountModel
    {
        public int PatientAccountId { get; set; }
        public int PatientId { get; set; }
        public int PractitionerAccountId { get; set; }

        public int PractitionerId { get; set; }
    }
}
