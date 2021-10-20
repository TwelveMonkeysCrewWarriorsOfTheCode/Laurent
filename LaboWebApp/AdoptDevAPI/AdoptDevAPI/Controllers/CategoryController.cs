using AdoptDevAPI.Models;
using AdoptDevAPI.Tools;
using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICRUDService<CategoryModel> _crudService;
        private IListService _categoryListeService;

        public CategoryController(ICRUDService<CategoryModel> crudService, IListService categoryListeService)
        {
            _crudService = crudService;
            _categoryListeService = categoryListeService;
        }

        [HttpPut]
        public IActionResult Create(CategoryModelAPI category)
        {
            try
            {
                _crudService.Create(category.CategoryModelAPIToDAL());
                return Ok("Create Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }           
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_crudService.GetAll().Select(c => c.CategoryModelDALToAPI()));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_crudService.GetById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }           
        }

        [HttpPost]
        public IActionResult Update(CategoryModelAPI category)
        {
            try
            {
                _crudService.Update(category.CategoryModelAPIToDAL());
                return Ok("Update Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }           
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                _crudService.Delete(id);
                return Ok("Delete Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
