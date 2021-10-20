using AdoptDevMVCDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevMVCDAL.Interfaces
{
    public interface IListRequester
    {
        IEnumerable<ContractModelDAL> GetByOwerId(int id);
        IEnumerable<ContractModelDAL> GetByDevId(int id);
        IEnumerable<NeededSkillModelDAL> SkillNameGetByContractId(int id);
        CategoryModelDAL CategoryNameGetBySkillId(int id);
    }
}
