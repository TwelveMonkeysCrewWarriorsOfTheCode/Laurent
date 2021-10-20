using AdoptDevMVC.Models;
using AdoptDevMVC.Tools;
using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdoptDevMVC.Controllers
{
    public class CategoryController : Controller
    {
        public ICRUDRequester<CategoryModelDAL> _requester;

        public CategoryController(ICRUDRequester<CategoryModelDAL> requester)
        {
            _requester = requester;
        }

        public IActionResult List()
        {
                return View(_requester.GetAll().Select(c => c.CategoryModelDALToView()));               
        }

        public IActionResult Details(int id)
        {
            return View(_requester.GetById(id).CategoryModelDALToView());
        }
    }
}
