using System.Collections.Generic;
using PatientWarningApp.Api.PatientAccount.Models;
using PatientWarningApp.Api.Shared.Models;

namespace PatientWarningApp.Api.PractitionerAccount.Models
{
    public class PractitionerAccountModel : AccountModel
    {
        public int PractitionerAccountId { get; set; }

        public List<PatientAccountModel> PatientAccounts { get; set; }
    }
}
