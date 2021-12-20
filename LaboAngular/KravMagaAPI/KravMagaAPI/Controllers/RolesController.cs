using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KravMagaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ICRUDServiceDAL<RoleModelDAL> _roleService;
        public RolesController(ICRUDServiceDAL<RoleModelDAL> roleService) => _roleService = roleService;

        [HttpGet]
        public IActionResult GetListMembers()
        {
            return Ok(_roleService.GetAll());
        }
    }
}
