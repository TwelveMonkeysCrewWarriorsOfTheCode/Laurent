namespace KravMagaAPI.Models
{
    public class MemberUpdateModel
    {
        internal int MemberId { get; set; } 
        internal string Email { get; set; }        
        internal string LastName { get; set; }
        internal string FirstName { get; set; }
        internal DateTime BirthDay { get; set; }
        internal string Adress { get; set; }
        internal string Phone { get; set; }
    }
}
