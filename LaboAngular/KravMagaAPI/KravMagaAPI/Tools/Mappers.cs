using KravMagaAPI.Models;
using KravMagaAPI.Models.LogIn;
using KravMagaAPI_DAL.Models_DAL;

namespace KravMagaAPI.Tools
{
    public static class Mappers
    {
        public static MemberModelDAL MemberInsertModelToMemberModelDAL(this MemberInsertModel member)
        {
            return new MemberModelDAL
            {
                Email = member.Email,
                Password = member.Password,
                LastName = member.LastName, 
                FirstName = member.FirstName,
                BirthDay = member.BirthDay,
                Adress = member.Adress,
                Phone = member.Phone
            };
        }

        public static MemberModelDAL MemberUpdateModelToMemberModelDAL(this MemberUpdateModel member)
        {
            return new MemberModelDAL
            {
                Id = member.MemberId,
                Email = member.Email,
                LastName = member.LastName,
                FirstName = member.FirstName,
                BirthDay = member.BirthDay,
                Adress = member.Adress,
                Phone = member.Phone
            };
        }

        public static LogInModelDAL LogInModelToLogInModelDAL(this LogInModel logIn)
        {
            return new LogInModelDAL
            {
                Email = logIn.Email,
                Password = logIn.Password
            };
        }

        public static BeLoggedModel BeLoggedModelDALToBeLoggedModel(this BeLoggedModelDAL blm)
        {
            return new BeLoggedModel
            {
                Id = blm.Id,
                Email = blm.Email,
                FirstName = blm.FirstName,
                LastName = blm.LastName,
                AutorisationID = blm.AutorisationID,    
            };
        }
    }
}
