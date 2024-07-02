using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.DTOs.UIGalleryDtos;
using MilkyProject.DtoLayer.DTOs.UISliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminGalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminGalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GalleryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Gallery");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);
                return View(values);
            }
            return View(null);
        }
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7159/api/Gallery?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GallleryList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddGallery(AddGalleryDto addGalleryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addGalleryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7159/api/Gallery", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GallleryList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Gallery/GetByIdGallery?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGalleryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGallery(UpdateGalleryDto updateGalleryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGalleryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7159/api/Gallery", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GallleryList");
            }
            return View();
        }
    }
}
