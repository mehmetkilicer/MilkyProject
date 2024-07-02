using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MilkyProject.DtoLayer.DTOs.UlAboutDtos;

namespace MilkyProject.WebUI.ViewComponents
{
    public class _UlAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UlAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
               var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values.FirstOrDefault());
            }
            return View(null);
        }
    }
}
