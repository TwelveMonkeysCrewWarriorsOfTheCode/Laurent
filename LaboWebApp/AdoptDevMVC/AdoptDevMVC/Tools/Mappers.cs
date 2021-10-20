using AdoptDevMVC.Models;
using AdoptDevMVC.Models.Security;
using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Tools
{
    public static class Mappers
    {
        // Mappers for UserModel
        public static UserModels.UserModel UserModelDALToView(this UserModelDAL user)
        {
            return new UserModels.UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                IsOwner = user.IsOwner
            };
        }

        public static UserModels.UserDisplayModel UserDisplayModelDALToView(this UserModelDAL user)
        {
            return new UserModels.UserDisplayModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                IsOwner = user.IsOwner
            };
        }

        public static UserModels.UserEditModel UserEditModelDALToView(this UserModelDAL user)
        {
            return new UserModels.UserEditModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                IsOwner = user.IsOwner
            };
        }

        public static UserModelDAL UserEditModelViewToDAL(this UserModels.UserEditModel user)
        {
            return new UserModelDAL
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                IsOwner = user.IsOwner
            };
        }

        // Mappers for RegisterModel
        public static UserModelDAL RegisterModelViewToDAL(this RegisterModel user)
        {
            return new UserModelDAL
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Phone = user.Phone,
                IsOwner = user.IsOwner
            };
        }

        // Mapers for CategoryModel
        public static CategoryModel CategoryModelDALToView(this CategoryModelDAL category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        // Mappers for LogInModel
        public static LogInModelDAL LogInModelViewToDAL(this LogInModel logIn)
        {
            return new LogInModelDAL
            {
                Email = logIn.Email,
                Password = logIn.Password
            };
        }

        // Mappers for BeLoggedModel
        public static BeLoggedModel BeLoggedModelDALToView(this BeLoggedModelDAL beLogged)
        {
            if (beLogged.Name != null)
            {
                BeLoggedModel blm = new();
                blm.Id = beLogged.Id;
                blm.Name = beLogged.Name;
                blm.UserType = (beLogged.IsOwner) ? "Owner" : "Dev";
                blm.LogOk = true;

                return blm;
            }
            else return new BeLoggedModel { LogOk = false };
        }

        // Mappers for ContractModel
        public static ContractModelDAL ContractModelViewToDAL(this ContractModel contract)
        {
            return new ContractModelDAL
            {
                Id = contract.Id,
                Description = contract.Description,
                Price = contract.Price,
                DeadLine = contract.DeadLine,
                OwnerId = contract.OwnerId,
                DevId = contract.DevId,
            };
        }

        public static ContractModel ContractModelDALToView(this ContractModelDAL contract)
        {
            return new ContractModel
            {
                Id = contract.Id,
                Description = contract.Description,
                Price = contract.Price,
                DeadLine = contract.DeadLine,
                OwnerId = contract.OwnerId,
                DevId = contract.DevId,               
            };
        }

        // Mapper for NeekdeSkilModel
        public static NeededSkillModel NeededSkillModelDALToView(this NeededSkillModelDAL neededSkill)
        {
            return new NeededSkillModel
            {
                Id = neededSkill.Id,
                ContractId = neededSkill.ContractId,
                SkillId = neededSkill.SkillId,
            };
        }

        public static NeededSkillModelDAL NeededSkillModelViewToDAL(this NeededSkillModel neededSkill)
        {
            return new NeededSkillModelDAL
            {
                Id = neededSkill.Id,
                ContractId = neededSkill.ContractId,
                SkillId = neededSkill.SkillId,
            };
        }

        // Mapper for Skill
        public static SkillModel SkillModelDALToView(this SkillModelDAL skill)
        {
            return new SkillModel
            {
                Id = skill.Id,
                Name = skill.Name,
                Description = skill.Description,
                CategoryId = skill.CategoryId
            };
        }

        // Mapper for UserSkill
        public static UserSkillModel UserSkillModelDALToView(this UserSkillModelDAL userSkill)
        {
            return new UserSkillModel
            {
                Id = userSkill.Id,
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId
            };
        }

        public static UserSkillModelDAL UserSkillModelViewToDAL(this UserSkillModel userSkill)
        {
            return new UserSkillModelDAL
            {
                Id = userSkill.Id,
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId
            };
        }
    }
}
