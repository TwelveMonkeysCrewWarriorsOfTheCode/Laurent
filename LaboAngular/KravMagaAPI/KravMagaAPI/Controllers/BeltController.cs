using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.AspNetCore.Mvc;

namespace KravMagaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeltController : ControllerBase
    {
        private readonly ICRUDServiceDAL<BeltModelDAL> _beltService;
        public BeltController(ICRUDServiceDAL<BeltModelDAL> beltService) => _beltService = beltService;

        [HttpGet]
        public IActionResult GetListMembers()
        {
            return Ok(_beltService.GetAll());
        }
    }
}
