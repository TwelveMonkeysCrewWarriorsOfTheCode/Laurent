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
    public class ContractController : ControllerBase
    {
        private ICRUDService<ContractModel> _crudService;

        public ContractController(ICRUDService<ContractModel> crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public IActionResult CreateIdReturn(ContractModelAPI contract)
        {
            try
            {
                //_crudService.Create(contract.ContractModelAPIToDAL());
                return Ok(_crudService.CreateIdReturn(contract.ContractModelAPIToDAL()).ContractModelDALToAPI());
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
                return Ok(_crudService.GetAll().Select(c => c.ContractModelDALToAPI()));
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
        public IActionResult Update(ContractModelAPI contract)
        {
            try
            {
                _crudService.Update(contract.ContractModelAPIToDAL());
                return Ok("Update Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
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
