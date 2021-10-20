using AdoptDevAPI.Models.Security;
using AdoptDevAPI.Tools;
using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SecurityController : ControllerBase
    {
        private ILoginService _logIn;

        public SecurityController(ILoginService logIn)
        {
            _logIn = logIn;
        }

        [HttpPost]
        public IActionResult LogIn(LogInModelAPI log)
        {
            try
            {
                BeLoggedModelAPI blm =(_logIn.LogIn(log.LogInModelViewToDAL())).BeLoggedModelDALToView();
                return Ok(blm);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
