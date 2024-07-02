using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        [HttpGet]
        public IActionResult GalleryList()
        {
            var values = _galleryService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGallery(Gallery gallery)
        {
            _galleryService.TInsert(gallery);
            return Ok("Gallery basarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteGallery(int id)
        {
            _galleryService.TDelete(id);
            return Ok("Galeri silindi");
        }
        [HttpGet("GetByIdGallery")]
        public IActionResult GetByIdGallery(int id)
        {
            var value = _galleryService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateGallery(Gallery gallery)
        {
            _galleryService.TUpdate(gallery);
            return Ok("Galeri başarıyla güncellendi.");

        }
    }
}
