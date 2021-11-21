using System.Collections.Generic;

namespace PatientWarningApp.Data.Entities
{
    public class PractitionerAccount : Account
    {
        public List<PatientAccount> PatientAccounts { get; set; }
    }
}
