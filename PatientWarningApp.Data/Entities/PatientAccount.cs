namespace PatientWarningApp.Data.Entities
{
    public class PatientAccount : Account
    {
        public int PatientId { get; set; }


        public int PractitionerId { get; set; }
        public PractitionerAccount Practitioner { get; set; }
    }
}
