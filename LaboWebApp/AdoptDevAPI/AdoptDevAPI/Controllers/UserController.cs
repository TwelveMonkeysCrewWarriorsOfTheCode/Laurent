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
    public class UserController : ControllerBase
    {
        private ICRUDService<UserModel> _crudService;

        public UserController(ICRUDService<UserModel> crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public IActionResult Create(UserModelAPI user)
        {
            try
            {
                _crudService.Create(user.UserModelAPIToDAL());
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
                return Ok(_crudService.GetAll().Select(c => c.UserModelDALToAPI()));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_crudService.GetById(id).UserModelDALToAPI());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UserModelAPI user)
        {
            try
            {
                _crudService.Update(user.UserModelAPIToDAL());
                return Ok("Update Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
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
