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
    public class UserSkillController : ControllerBase
    {
        private readonly ICRUDService<UserSkillModel> _userSkill;

        public UserSkillController(ICRUDService<UserSkillModel> userSkill)
        {
            _userSkill = userSkill;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userSkill.GetAll().Select(c => c.UserSkillModelDALToAPI()));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UserSkillModelAPI userSkill)
        {
            try
            {
                _userSkill.Update(userSkill.UserSkillModelAPIToDAL());
                return Ok("Update Ok");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
