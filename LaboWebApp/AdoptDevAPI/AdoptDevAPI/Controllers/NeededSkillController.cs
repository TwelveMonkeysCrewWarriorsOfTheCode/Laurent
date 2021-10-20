using AdoptDevAPI.Models;
using AdoptDevAPI.Tools;
using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AdoptDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeededSkillController : ControllerBase
    {
        private readonly IListService _listService;
        private readonly ICRUDService<NeededSkillModel> _neededSkillService;

        public NeededSkillController(IListService listService, ICRUDService<NeededSkillModel> neededSkillService)
        {
            _listService = listService;
            _neededSkillService = neededSkillService;
        }

        [HttpPost]
        public IActionResult Create(NeededSkillModelAPI neededSkill)
        {
            try
            {
                _neededSkillService.Create(neededSkill.NeededSkillModelViewToDAL());
                return Ok("création réussie");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult SkillNameGetByContractId(int id)
        {
            try
            {
                return Ok(_listService.SkillNameGetByContractId(id).Select(ns => ns.NeededSkillModelDALToView()));
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
                return Ok(_neededSkillService.GetAll().Select(ns => ns.NeededSkillModelDALToView()));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(NeededSkillModelAPI neededSkill)
        {

            _neededSkillService.Update(neededSkill.NeededSkillModelViewToDAL());
            return Ok("Mise à jour réussie");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _neededSkillService.Delete(id);
                return Ok("Delete Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
