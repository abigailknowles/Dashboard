namespace PatientWarningApp.Api.Shared.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
