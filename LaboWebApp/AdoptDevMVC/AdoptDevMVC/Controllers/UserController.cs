using AdoptDevMVC.Models;
using AdoptDevMVC.Tools;
using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdoptDevMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICRUDRequester<UserModelDAL> _user;
        private readonly ISecurityRequester _security;

        public UserController(ICRUDRequester<UserModelDAL> requester, ISecurityRequester security)
        {
            _user = requester;
            _security = security;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterModel form)
        {
            if (ModelState.IsValid && !_security.EmailExist(form.RegisterModelViewToDAL()))
            {
                _user.Create(form.RegisterModelViewToDAL());
                TempData["info"] = "Vous êtes bien enregistré";
                return this.RedirectToAction("Index","Home");
            }
            if (form.Email != null) TempData["error"] = "L'email existe déjà";
            return View(form);
        }

        public IActionResult List()
        {
            return View(_user.GetAll().Select(u => u.UserModelDALToView()));
        }
    }
}
