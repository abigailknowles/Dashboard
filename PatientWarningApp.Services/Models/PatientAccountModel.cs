namespace PatientWarningApp.Services.Models
{
    public class PatientAccountModel : AccountModel
    {
        public int PatientAccountId { get; set; }
        public int PractitionerAccountId { get; set; }

        public int PractitionerId { get; set; }
    }
}
