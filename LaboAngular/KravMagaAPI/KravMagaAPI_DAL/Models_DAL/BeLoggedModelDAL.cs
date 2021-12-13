using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KravMagaAPI_DAL.Models_DAL
{
    internal class BeLoggedModelDAL
    {
        internal int Id { get; set; }
        internal string Email { get; set; }
        internal string LastName { get; set; }
        internal string FirstName { get; set; }
        internal int AutorisationID { get; set; }
    }
}
