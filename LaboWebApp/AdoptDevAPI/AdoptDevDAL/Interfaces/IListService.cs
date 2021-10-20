using AdoptDevDAL.Models;
using System.Collections.Generic;

namespace AdoptDevDAL.Interfaces
{
    public interface IListService
    {
        IEnumerable<NeededSkillModel> SkillNameGetByContractId(int id);
    }
}
