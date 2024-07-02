using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.DTOs.UIGalleryDtos;
using MilkyProject.DtoLayer.DTOs.UIMemberDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminMemberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMemberController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MemberList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Member");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMemberDto>>(jsonData);
                return View(values);
            }
            return View(null);
        }
        public async Task<IActionResult> DeleteMember(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7159/api/Member?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MemberList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberDto addMemberDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addMemberDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7159/api/Member", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MemberList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMember(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Member/GetByIdMember?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMemberDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMember(UpdateMemberDto updateMemberDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMemberDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7159/api/Member", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MemberList");
            }
            return View();
        }

    }
}
