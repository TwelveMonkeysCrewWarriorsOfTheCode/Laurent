using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KravMagaAPI_DAL.Models_DAL
{
    public class MemberModelDAL
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        //internal bool Subscription { get; set; }
        public DateTime LastDateSubscription { get; set; }
        public int AuthorisationID { get; set; }
        public int RoleID { get; set; }
        public int BeltID { get; set; }
        //internal string AutorisationType { get; set; }
        //internal string Role { get; set; }
        //internal string BeltColor { get; set; }
    }
}
