using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
           var values = _serviceService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.TInsert(service);
            return Ok("Servis basarıyla eklendi");
        }
        [HttpGet("GetByIdService")]
        public IActionResult GetByIdService(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok("Hizmet başarıyla güncellendi.");

        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return Ok("Hizmet silindi");
        }
    }
}
