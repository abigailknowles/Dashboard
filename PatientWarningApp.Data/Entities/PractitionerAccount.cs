using System.Collections.Generic;

namespace PatientWarningApp.Data.Entities
{
    public class PractitionerAccount : Account
    {
        public int PractitionerAccountId { get; set; }
        public List<PatientAccount> PatientAccounts { get; set; }
    }
}
