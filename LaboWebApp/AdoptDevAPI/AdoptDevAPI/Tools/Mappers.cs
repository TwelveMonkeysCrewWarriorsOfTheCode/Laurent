using AdoptDevAPI.Models;
using AdoptDevAPI.Models.Security;
using AdoptDevDAL.Models;
using AdoptDevDAL.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevAPI.Tools
{
    public static class Mappers
    {
        // Mappers for CategoryModel
        public static CategoryModel CategoryModelAPIToDAL (this CategoryModelAPI categoryAPI)
        {
            return new CategoryModel
            {
                Id = categoryAPI.Id,
                Name = categoryAPI.Name
            };
        }

        public static CategoryModelAPI CategoryModelDALToAPI(this CategoryModel categoryDAL)
        {
            return new CategoryModelAPI
            {
                Id = categoryDAL.Id,
                Name = categoryDAL.Name
            };
        }

        // Mappers forContract
        public static ContractModel ContractModelAPIToDAL (this ContractModelAPI contractAPI)
        {
            ContractModel contract = new();
            contract.Id = contractAPI.Id;
            contract.Description = contractAPI.Description;
            contract.Price = contractAPI.Price;
            contract.DeadLine = contractAPI.DeadLine;
            contract.OwnerId = contractAPI.OwnerId;
            contract.DevId = (contractAPI.DevId == 0)? null:contractAPI.DevId;
            return contract;
        }

        public static ContractModelAPI ContractModelDALToAPI(this ContractModel contractDAL)
        {
            return new ContractModelAPI
            {
                Id = contractDAL.Id,
                Description = contractDAL.Description,
                Price = contractDAL.Price,
                DeadLine = contractDAL.DeadLine,
                OwnerId = contractDAL.OwnerId,
                DevId = contractDAL.DevId,
            };
        }

        // Mappers for SkillModel
        public static SkillModel SkillModelAPIToDAL(this SkillModelAPI skillModelAPI)
        {
            return new SkillModel
            {
                Id = skillModelAPI.Id,
                Name = skillModelAPI.Name,
                Description = skillModelAPI.Description,
                CategoryId = skillModelAPI.CategoryId
            };
        }

        public static SkillModelAPI SkillModelDALToAPI(this SkillModel skillModelAPI)
        {
            return new SkillModelAPI
            {
                Id = skillModelAPI.Id,
                Name = skillModelAPI.Name,
                Description = skillModelAPI.Description,
                CategoryId = skillModelAPI.CategoryId
            };
        }

        // Mappers for UserModel
        public static UserModel UserModelAPIToDAL(this UserModelAPI userAPI)
        {
            return new UserModel
            {
                Id = userAPI.Id,
                Email = userAPI.Email,
                Password = userAPI.Password,
                Name = userAPI.Name,
                Phone = userAPI.Phone,
                IsOwner = userAPI.IsOwner
            };
        }

        public static UserModelAPI UserModelDALToAPI(this UserModel userDAL)
        {
            return new UserModelAPI
            {
                Id = userDAL.Id,
                Email = userDAL.Email,
                Password = userDAL.Password,
                Name = userDAL.Name,
                Phone = userDAL.Phone,
                IsOwner = userDAL.IsOwner
            };
        }

        // Mappers for LogInModel
        public static LogInModel LogInModelViewToDAL(this LogInModelAPI logIn)
        {
            return new LogInModel
            {
                Email = logIn.Email,
                Password = logIn.Password
            };
        }

        // Mappers for BeLoggedModel
        public static BeLoggedModelAPI BeLoggedModelDALToView(this BeLoggedModel beLogged)
        {
            if (beLogged != null)
            {
                return new BeLoggedModelAPI
                {
                    Id = beLogged.Id,
                    Name = beLogged.Name,
                    IsOwner = beLogged.IsOwner,
                    LogOk = true
                };
            }
            else return new BeLoggedModelAPI { LogOk = false };
        }
        
        // Mapper for NeekdeSkilModel
        public static NeededSkillModelAPI NeededSkillModelDALToView(this NeededSkillModel neededSkill)
        {
            return new NeededSkillModelAPI
            {
                Id = neededSkill.Id,
                ContractId = neededSkill.ContractId,
                SkillId = neededSkill.SkillId,
            };
        }

        public static NeededSkillModel NeededSkillModelViewToDAL(this NeededSkillModelAPI neededSkill)
        {
            return new NeededSkillModel
            {
                Id = neededSkill.Id,
                ContractId = neededSkill.ContractId,
                SkillId = neededSkill.SkillId,
            };
        }

        // Mapper for UserSkillModel
        public static UserSkillModelAPI UserSkillModelDALToAPI(this UserSkillModel userSkill)
        {
            return new UserSkillModelAPI
            {
                Id = userSkill.Id,
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId
            };
        }

        public static UserSkillModel UserSkillModelAPIToDAL(this UserSkillModelAPI userSkill)
        {
            return new UserSkillModel
            {
                Id = userSkill.Id,
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId
            };
        }
    }
}
