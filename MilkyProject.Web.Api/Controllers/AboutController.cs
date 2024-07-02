using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.BusinessLayer.Concrete;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values =_aboutService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAbout(About about) 
        {
            _aboutService.TInsert(about);
            return Ok("About Basarıyla eklendi");
        }
        [HttpGet("GetByIdAbout")]
        public IActionResult GetByIdAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider(About about)
        {
            _aboutService.TUpdate(about);
            return Ok("Ürün başarıyla güncellendi.");

        }
    }
}
