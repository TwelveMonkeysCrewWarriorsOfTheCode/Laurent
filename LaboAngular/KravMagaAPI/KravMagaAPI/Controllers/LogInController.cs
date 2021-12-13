using KravMagaAPI.Models.LogIn;
using KravMagaAPI.Securities;
using KravMagaAPI.Tools;
using KravMagaAPI_DAL.Services_DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KravMagaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly LogInServiceDAL _logInService;
        public LogInController(LogInServiceDAL logInService) => _logInService = logInService;

        [HttpPost]
        public IActionResult LogIn(LogInModel log)
        {
            //log.Password = HashPassword.Hash(log.Password);
            BeLoggedModel blm = (_logInService.LogIn(log.LogInModelToLogInModelDAL())).BeLoggedModelDALToBeLoggedModel();           
            return Ok(blm);
            BCrypt 
        }
    }
}
