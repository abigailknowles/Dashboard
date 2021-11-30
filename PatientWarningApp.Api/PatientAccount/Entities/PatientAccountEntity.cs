using PatientWarningApp.Api.Shared.Entities;

namespace PatientWarningApp.Api.PatientAccount.Entities
{
    public class PatientAccountEntity : Account
    {
        public int PatientAccountId { get; set; }
        public int PatientId { get; set; }
        public int PractitionerAccountId { get; set; }

    }
}
