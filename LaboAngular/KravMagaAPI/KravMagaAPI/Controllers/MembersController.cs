using KravMagaAPI.Models;
using KravMagaAPI.Models.LogIn;
using KravMagaAPI.Securities;
using KravMagaAPI.Tools;
using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.AspNetCore.Mvc;

namespace KravMagaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberServiceDAL<MemberModelDAL> _memberService;
        public MembersController(IMemberServiceDAL<MemberModelDAL> memberService) =>_memberService = memberService; 

        [HttpPut]
        public IActionResult InsertMember(MemberInsertModel member)
        {
            //member.Password = HashPassword.Hash(member.Password);
            BeLoggedModel blm = _memberService.Create(member.MemberInsertModelToMemberModelDAL()).BeLoggedModelDALToBeLoggedModel();
            return Ok(blm);
        }

        [HttpGet]
        public IActionResult GetListMembers()
        {
            
            return Ok(_memberService.GetAll());      
        }

        [HttpGet("id")]
        public IActionResult GetMember(int id)
        {
            return Ok(_memberService.GetById(id)); 
        }

        [HttpPost("id")]
        public IActionResult UpdateMember(MemberUpdateModel member)
        {
            _memberService.Update(member.MemberUpdateModelToMemberModelDAL());
            return Ok("Update ok");
        }

        [HttpDelete("id")]
        public IActionResult DeleteMember(int id)
        {
            _memberService.Delete(id);
            return Ok("Delete ok");
        }
    }
}
