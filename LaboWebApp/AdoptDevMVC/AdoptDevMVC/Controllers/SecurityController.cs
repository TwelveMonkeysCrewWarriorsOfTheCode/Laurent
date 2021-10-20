using AdoptDevMVC.Models.Security;
using AdoptDevMVC.Tools;
using AdoptDevMVCDAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptDevMVC.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISecurityRequester _logIn;

        public SecurityController(IHttpContextAccessor httpContextAccessor, ISecurityRequester logIn)
        {
            _httpContextAccessor = httpContextAccessor;
            _logIn = logIn;
        }
        
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogInModel form)
        {
            BeLoggedModel beLogged = _logIn.LogIn(form.LogInModelViewToDAL()).BeLoggedModelDALToView();
            
            if (beLogged.LogOk == true)
            {
                HttpContext.Session.SetInt32("Id", beLogged.Id);
                HttpContext.Session.SetString("Name", beLogged.Name);
                HttpContext.Session.SetString("UserType", beLogged.UserType);
                TempData["info"] = $"Bienvenue {beLogged.Name}";
                return (_httpContextAccessor.HttpContext.Session.GetString("UserType") == "Owner") ? this.RedirectToAction("Index", "Owner") : this.RedirectToAction("Index", "Dev");
            }
            else
            {
                return View(form);
            }
        }

        public IActionResult LogOff()
        {
            TempData["info"] = $"Aurevoir {_httpContextAccessor.HttpContext.Session.GetString("Name")}";
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult BeLogged(BeLoggedModel beLogged)
        {
            return View(beLogged);
        }
    }
}
