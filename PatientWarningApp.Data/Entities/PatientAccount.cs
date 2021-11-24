namespace PatientWarningApp.Data.Entities
{
    public class PatientAccount : Account
    {
        public int PatientId { get; set; }
        public int PractitionerAccountId { get; set; }
        public int PatientAccountId { get; set; }
    }
}
