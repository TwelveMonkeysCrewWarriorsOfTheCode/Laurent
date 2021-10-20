using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevMVCDAL.Interfaces
{
    public interface ISecurityRequester
    {
        public BeLoggedModelDAL LogIn(LogInModelDAL logIn);
        public bool EmailExist(UserModelDAL register);
    }
}
