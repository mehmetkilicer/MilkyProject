using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.BusinessLayer.Concrete;
using MilkyProject.DataAccessLayer.EntityFramework;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult GetSliders()
        {
            var values = _sliderService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSlider(Slider slider)
        {
            _sliderService.TInsert(slider);
            return Ok("Slider Basarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            _sliderService.TDelete(id);
            return Ok("Slider silindi");
        }
        [HttpGet("GetByIdSlider")]
        public IActionResult GetByIdSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider(Slider slider)
        {
            _sliderService.TUpdate(slider);
            return Ok("Ürün başarıyla güncellendi.");

        }
    }
}
