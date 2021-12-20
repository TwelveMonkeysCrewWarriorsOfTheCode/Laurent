using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.AspNetCore.Mvc;

namespace KravMagaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorisationsController : ControllerBase
    {
        private readonly ICRUDServiceDAL<AuthorisationModelDAL> _authorisationService;
        public AuthorisationsController(ICRUDServiceDAL<AuthorisationModelDAL> authorisationService) => _authorisationService = authorisationService;

        [HttpGet]
        public IActionResult GetListMembers()
        {
            return Ok(_authorisationService.GetAll());
        }
    }
}
