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
    public class OwnerController : Controller
    {
        private readonly ICRUDRequester<ContractModelDAL> _contract;
        private readonly ICRUDRequester<CategoryModelDAL> _category;
        private readonly ICRUDRequester<SkillModelDAL> _skill;
        private readonly ICRUDRequester<UserModelDAL> _user;
        private readonly ICRUDRequester<NeededSkillModelDAL> _neededSkill;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IListRequester _list;

        public OwnerController(ICRUDRequester<ContractModelDAL> contract, ICRUDRequester<CategoryModelDAL> category, ICRUDRequester<SkillModelDAL> skill,ICRUDRequester<UserModelDAL> user, ICRUDRequester<NeededSkillModelDAL> neededSkill, IHttpContextAccessor httpContextAccessor, IListRequester list)
        {
            _contract = contract;
            _category = category;
            _skill = skill;
            _user = user;
            _neededSkill = neededSkill;
            _httpContextAccessor = httpContextAccessor;
            _list = list;            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContract()
        {
            ContractModel contract = new();
            contract.DevList = _user.GetAll().Where(u => u.IsOwner == false).Select(u => u.UserModelDALToView());
            contract.SkillList = _skill.GetAll().Select(s => s.SkillModelDALToView()).ToList();            
            foreach (var skillList in contract.SkillList)
            {
                skillList.CategoryName = _category.GetById(skillList.CategoryId).CategoryModelDALToView().Name;
            }
            return View(contract);
        }

        [HttpPost]
        public IActionResult CreateContract(ContractModel form)
        {
            if (ModelState.IsValid)
            {               
                form.OwnerId = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
                int contractId = _contract.CreateIdReturn(form.ContractModelViewToDAL()).ContractModelDALToView().Id;
                NeededSkillModel neededSkill = new();
                neededSkill.ContractId = contractId;
                neededSkill.SkillId = form.SkillDBId;
                _neededSkill.Create(neededSkill.NeededSkillModelViewToDAL());
                neededSkill.SkillId = form.SkillBackId;
                _neededSkill.Create(neededSkill.NeededSkillModelViewToDAL());
                neededSkill.SkillId = form.SkillFrontId;
                _neededSkill.Create(neededSkill.NeededSkillModelViewToDAL());

                TempData["info"] = "Contrat bien enregistré";
                return this.RedirectToAction("Index", "Owner");
            }            
            return View(form);
        }
       
        public IActionResult ListContract()
        {
            IEnumerable<ContractModel> contractList = _list.GetByOwerId((int)_httpContextAccessor.HttpContext.Session.GetInt32("Id")).Select(c => c.ContractModelDALToView()).ToList();

            foreach(ContractModel contract in contractList)
            {
                if(contract.DevId != null)
                {
                    contract.DevName = _user.GetById((int)contract.DevId).UserModelDALToView().Name;
                    contract.DevEmail = _user.GetById((int)contract.DevId).UserModelDALToView().Email;                    
                }
                contract.OwnerName = _user.GetById((int)contract.OwnerId).UserModelDALToView().Name;
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
            
        public IActionResult EditContract(int id)
        {
            ContractModel contract = _contract.GetById(id).ContractModelDALToView();           
            contract.DevList = _user.GetAll().Where(u => u.IsOwner == false).Select(u => u.UserModelDALToView());
            contract.SkillList = _skill.GetAll().Select(s => s.SkillModelDALToView()).ToList();
            contract.CategoryList = _category.GetAll().Select(c => c.CategoryModelDALToView());
            contract.OwnerName = _user.GetById((int)contract.OwnerId).UserModelDALToView().Name;
            contract.NeededSkillList = _neededSkill.GetAll().Where(ns => ns.ContractId == contract.Id).Select(ns => ns.NeededSkillModelDALToView()).ToList();
            foreach (var skillList in contract.SkillList)
            {
                skillList.CategoryName = _category.GetById(skillList.CategoryId).CategoryModelDALToView().Name;
            }
            foreach (var neededSkillList in contract.NeededSkillList)
            {
                neededSkillList.CategoryId = _skill.GetById(neededSkillList.SkillId).CategoryId;
                neededSkillList.CategoryName = _category.GetById(neededSkillList.CategoryId).CategoryModelDALToView().Name;
                neededSkillList.SkillName = _skill.GetById(neededSkillList.SkillId).SkillModelDALToView().Name;
                if (neededSkillList.CategoryName == "Base de données") contract.SkillDBId = neededSkillList.SkillId;
                if (neededSkillList.CategoryName == "Backend") contract.SkillBackId = neededSkillList.SkillId;
                if (neededSkillList.CategoryName == "Frontend") contract.SkillFrontId = neededSkillList.SkillId;
            }
            return View(contract);
        }

        [HttpPost]
        public IActionResult EditContract(ContractModel model)
        {
            if (ModelState.IsValid)
            {
                _contract.Update(model.ContractModelViewToDAL());
                model.NeededSkillList = _neededSkill.GetAll().Where(ns => ns.ContractId == model.Id).Select(ns => ns.NeededSkillModelDALToView()).ToList();

                foreach (var neededSkillList in model.NeededSkillList)
                {
                    neededSkillList.CategoryId = _skill.GetById(neededSkillList.SkillId).CategoryId;
                    neededSkillList.CategoryName = _category.GetById(neededSkillList.CategoryId).CategoryModelDALToView().Name;
                    if (neededSkillList.CategoryName == "Base de données") neededSkillList.SkillId = model.SkillDBId;
                    if (neededSkillList.CategoryName == "Backend") neededSkillList.SkillId = model.SkillBackId;
                    if (neededSkillList.CategoryName == "Frontend") neededSkillList.SkillId = model.SkillFrontId;
                    _neededSkill.Update(neededSkillList.NeededSkillModelViewToDAL());
                }
                TempData["success"] = "Edition réussie";
                return RedirectToAction("ListContract");
            }
            return View(model);
        }
        
        public IActionResult DeleteContract(int id)
        {
            IEnumerable<NeededSkillModel> neededSkill = _neededSkill.GetAll().Where(ns => ns.ContractId == id).Select(ns => ns.NeededSkillModelDALToView());
            foreach(var neededSkillList in neededSkill)
            {
                _neededSkill.Delete(neededSkillList.Id);
            }
            _contract.Delete(id);
            return View("Index");
        }
    }
}