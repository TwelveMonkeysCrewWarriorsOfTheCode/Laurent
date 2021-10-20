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
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private ICRUDService<SkillModel> _crudService;

        public SkillController(ICRUDService<SkillModel> crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public IActionResult Create(SkillModelAPI skill)
        {
            try
            {
                _crudService.Create(skill.SkillModelAPIToDAL());
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
                return Ok(_crudService.GetAll().Select(c => c.SkillModelDALToAPI()));
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

        [HttpPut]
        public IActionResult Update(SkillModelAPI skill)
        {
            try
            {
                _crudService.Update(skill.SkillModelAPIToDAL());
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
