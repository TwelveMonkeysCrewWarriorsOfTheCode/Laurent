using AdoptDevMVC.Models;
using AdoptDevMVC.Tools;
using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdoptDevMVC.Controllers
{
    public class DevController : Controller
    {
        private readonly ICRUDRequester<ContractModelDAL> _contract;
        private readonly ICRUDRequester<CategoryModelDAL> _category;
        private readonly ICRUDRequester<SkillModelDAL> _skill;
        private readonly ICRUDRequester<UserModelDAL> _user;
        private readonly ICRUDRequester<NeededSkillModelDAL> _neededSkill;
        private readonly ICRUDRequester<UserSkillModelDAL> _userSkill;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DevController(ICRUDRequester<ContractModelDAL> contract, ICRUDRequester<CategoryModelDAL> category, ICRUDRequester<SkillModelDAL> skill, ICRUDRequester<UserModelDAL> user, ICRUDRequester<NeededSkillModelDAL> neededSkill, ICRUDRequester<UserSkillModelDAL> userSkill,IHttpContextAccessor httpContextAccessor)
        {
            _contract = contract;
            _category = category;
            _skill = skill;
            _user = user;
            _neededSkill = neededSkill;
            _userSkill = userSkill;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListContractAvailable()
        {
            IEnumerable<ContractModel> contractList = _contract.GetAll().Where(c => c.DevId == null).Select(c => c.ContractModelDALToView()).ToList();

            foreach (ContractModel contract in contractList)
            {
                contract.OwnerName = _user.GetById((int)contract.OwnerId).UserModelDALToView().Name;
                contract.OwnerEmail = _user.GetById((int)contract.OwnerId).UserModelDALToView().Email;
                contract.NeededSkillList = _neededSkill.GetAll().Where(ns => ns.ContractId == contract.Id).Select(ns => ns.NeededSkillModelDALToView()).ToList();
                foreach (var neededSkillList in contract.NeededSkillList)
                {
                    neededSkillList.CategoryId = _skill.GetById(neededSkillList.SkillId).CategoryId;
                    neededSkillList.SkillName = _skill.GetById(neededSkillList.SkillId).Name;
                    neededSkillList.CategoryName = _category.GetById(neededSkillList.CategoryId).CategoryModelDALToView().Name;
                }
            }
            return View(contractList);
        }

        public IActionResult ListOfYourContract()
        {
            IEnumerable<ContractModel> contractList = _contract.GetAll().Where(c => c.DevId == _httpContextAccessor.HttpContext.Session.GetInt32("Id")).Select(c => c.ContractModelDALToView()).ToList();

            foreach (ContractModel contract in contractList)
            {
                contract.OwnerName = _user.GetById((int)contract.OwnerId).UserModelDALToView().Name;
                contract.OwnerEmail = _user.GetById((int)contract.OwnerId).UserModelDALToView().Email;
                contract.NeededSkillList = _neededSkill.GetAll().Where(ns => ns.ContractId == contract.Id).Select(ns => ns.NeededSkillModelDALToView()).ToList();
                foreach (var neededSkillList in contract.NeededSkillList)
                {
                    neededSkillList.CategoryId = _skill.GetById(neededSkillList.SkillId).CategoryId;
                    neededSkillList.SkillName = _skill.GetById(neededSkillList.SkillId).Name;
                    neededSkillList.CategoryName = _category.GetById(neededSkillList.CategoryId).CategoryModelDALToView().Name;
                }
                
            }
            return View(contractList);
        }

        public IActionResult DisplayProfile()
        {

            UserModels.UserDisplayModel user = _user.GetById((int)_httpContextAccessor.HttpContext.Session.GetInt32("Id")).UserDisplayModelDALToView();
            user.UserSkillList = _userSkill.GetAll().Where(us => us.UserId == user.Id).Select(ns => ns.UserSkillModelDALToView()).ToList();
            foreach (var list in user.UserSkillList)
            {
                list.Skill = _skill.GetById(list.SkillId).SkillModelDALToView();
                list.Skill.CategoryName = _category.GetById(list.Skill.CategoryId).CategoryModelDALToView().Name;
            }
            return View(user);
        }

        public IActionResult EditProfile(int id)
        {
            UserModels.UserEditModel user = _user.GetById((int)_httpContextAccessor.HttpContext.Session.GetInt32("Id")).UserEditModelDALToView();
            user.UserSkillList = _userSkill.GetAll().Where(us => us.UserId == user.Id).Select(ns => ns.UserSkillModelDALToView()).ToList();
            user.SkillList = _skill.GetAll().Select(s => s.SkillModelDALToView()).ToList();
            foreach(var userSkillList in user.UserSkillList)
            {
                userSkillList.Skill = _skill.GetById(userSkillList.SkillId).SkillModelDALToView();
                userSkillList.Skill.CategoryName = _category.GetById(userSkillList.Skill.CategoryId).CategoryModelDALToView().Name;
            }
            foreach(var skillList in user.SkillList)
            {
                skillList.CategoryName = _category.GetById(skillList.CategoryId).CategoryModelDALToView().Name;
            }
            user.SkillList = user.SkillList.OrderBy(s => s.CategoryName).ToList();

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(UserModels.UserEditModel user)
        {
            if (ModelState.IsValid)
            {
                _user.Update(user.UserEditModelViewToDAL());
                
                foreach(var userSkillList in user.UserSkillList)
                {
                    _userSkill.Update(userSkillList.UserSkillModelViewToDAL());
                }
                return RedirectToAction("Index");
                /*foreach(var tuple in user.UserSkillList.Zip(user.SkillList,(x,y)=>(userSkillList:x,skillList:y)))
                {
                    tuple.userSkillList.SkillId = tuple.skillList.Id;
                    _userSkill.Update(tuple.userSkillList.UserSkillModelViewToDAL());
                }*/
            }
                
            /*foreach (var list in user.UserSkillList)
            {
                list.Skill = _skill.GetById(list.SkillId).SkillModelDALToView();
                list.Skill.CategoryName = _category.GetById(list.Skill.CategoryId).CategoryModelDALToView().Name;
            }*/
            return View(user);
        }
    }
}
