using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok("referans Basarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Testimonial silindi");
        }
        [HttpGet("GetByIdTestimonial")]
        public IActionResult GetByIdTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok("Testimonial başarıyla güncellendi.");

        }
    }
}
