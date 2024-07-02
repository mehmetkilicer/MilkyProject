using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.DTOs.UISliderDtos;
using Newtonsoft.Json;
using MilkyProject.DtoLayer.DTOs.UISliderDtos;
using System.Text;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SliderList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Slider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View(null);
        }
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7159/api/Slider?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddSlider()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddSlider(AddSliderDto addSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7159/api/Slider", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Slider/GetByIdSlider?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7159/api/Slider", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList");
            }
            return View();
        }
    }
}
