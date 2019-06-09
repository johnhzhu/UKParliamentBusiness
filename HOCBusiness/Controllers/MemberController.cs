using Microsoft.AspNetCore.Mvc;
using HOCBusiness.Domain;
using HOCBusiness.Services;
using Microsoft.Extensions.Configuration;

namespace HOCBusiness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;
        public MemberController(MemberService memberService, IConfiguration config)
        {
            _memberService = memberService;
        }
        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            return _memberService.GetMember(id);
        }
    }
}