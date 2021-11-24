using System.Collections.Generic;

namespace PatientWarningApp.Services.Models
{
    public class PractitionerAccountModel : AccountModel
    {
        public int PractitionerAccountId { get; set; }

        public List<PatientAccountModel> PatientAccounts { get; set; }
    }
}
