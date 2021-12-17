using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KravMagaAPI_DAL.Models_DAL
{
    public class BeLoggedModelDAL
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int AuthorisationID { get; set; }
    }
}
