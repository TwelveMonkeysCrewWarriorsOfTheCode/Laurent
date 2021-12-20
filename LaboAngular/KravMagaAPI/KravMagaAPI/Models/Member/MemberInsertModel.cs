namespace KravMagaAPI.Models
{
    public class MemberInsertModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

    }
}
