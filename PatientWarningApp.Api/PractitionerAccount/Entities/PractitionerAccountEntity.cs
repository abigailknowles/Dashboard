using System.Collections.Generic;
using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.Shared.Entities;

namespace PatientWarningApp.Api.PractitionerAccount.Entities
{
    public class PractitionerAccountEntity : Account
    {
        public int PractitionerAccountId { get; set; }
        public int PractitionerId { get; set; }
        public List<PatientAccountEntity> PatientAccounts { get; set; }
    }
}
