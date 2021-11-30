namespace PatientWarningApp.Services.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string SeizureTypes { get; set; }
        public string SeizureFrequencies { get; set; }
        public string SeizureTimes { get; set; }
        public string SeizureTriggers { get; set; }
        public string SideEffects { get; set; }
        public string Notes { get; set; }
    }
}