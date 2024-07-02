using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.DTOs.UIContactDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Area("Admin")]
        public async Task<IActionResult> Dashboard()
        {
            var clientContact = _httpClientFactory.CreateClient();
            var responseMessageMail= await clientContact.GetAsync("https://localhost:7159/api/Contact/GetMessageCount");

            var clientProductCount= _httpClientFactory.CreateClient();
            var responseMessageProductCount= await clientProductCount.GetAsync("https://localhost:7159/api/Product/GetProductCount");

            var clientProductAvg= _httpClientFactory.CreateClient();
            var responseMessageProductAvg= await clientProductAvg.GetAsync("https://localhost:7159/api/Product/GetProductAvg");

            var clientMemberCount= _httpClientFactory.CreateClient();
            var responseMessageMemberCount= await clientMemberCount.GetAsync("https://localhost:7159/api/Member/GetMemberCount");


            if (responseMessageMail.IsSuccessStatusCode)
            {
                var jsonDataMail =await responseMessageMail.Content.ReadAsStringAsync();
                ViewBag.messageCount = jsonDataMail;

                var jsonDataProductCount= await responseMessageProductCount.Content.ReadAsStringAsync();
                ViewBag.productCount = jsonDataProductCount;

                var jsonDataProductAvg= await responseMessageProductAvg.Content.ReadAsStringAsync();
                var value = double.Parse(jsonDataProductAvg);
                ViewBag.productAvg = value;

                var jsonDataMemberCount = await responseMessageMemberCount.Content.ReadAsStringAsync();
                ViewBag.memberCount = jsonDataMemberCount;



            }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View(null);
        }
    }
}
