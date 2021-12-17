namespace KravMagaAPI.Models.LogIn
{
    public class BeLoggedModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int AuthorisationID { get; set; }
        public bool LogOk { get; set; }
    }
}
