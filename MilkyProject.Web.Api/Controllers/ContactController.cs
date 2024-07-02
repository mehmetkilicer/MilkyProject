using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.TInsert(contact);
            return Ok("Contact basarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Ok("Contact silindi");
        }
        [HttpGet("GetByIdContact")]
        public IActionResult GetByIdContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok("Contact başarıyla güncellendi.");

        }
        [HttpGet("GetMessageCount")]
        public IActionResult GetMessageCount()
        {
            var contex = new MilkyContext();
            var count =contex.Contacts.Count();
            return Ok(count);
        }

    }
}
