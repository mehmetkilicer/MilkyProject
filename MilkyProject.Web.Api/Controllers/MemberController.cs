using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public IActionResult MemberList()
        {
            var values = _memberService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            _memberService.TInsert(member);
            return Ok("member Basarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteMember(int id)
        {
            _memberService.TDelete(id);
            return Ok("Member silindi");
        }
        [HttpGet("GetByIdMember")]
        public IActionResult GetByIdMember(int id)
        {
            var value = _memberService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateMember(Member member)
        {
            _memberService.TUpdate(member);
            return Ok("Member başarıyla güncellendi.");

        }
        [HttpGet("GetMemberCount")]
        public IActionResult GetMemberCount()
        {
            var contex = new MilkyContext();
            var count = contex.Members.Count();
            return Ok(count);
        }
    }
}
