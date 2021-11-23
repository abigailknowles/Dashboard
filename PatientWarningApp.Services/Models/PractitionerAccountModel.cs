using System.Collections.Generic;

namespace PatientWarningApp.Services.Models
{
    public class PractitionerAccountModel : AccountModel
    {
        public List<PatientAccountModel> PatientAccounts { get; set; }
    }
}
