using KravMagaAPI.Models;
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
    }
}
