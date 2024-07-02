using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.DTOs.UIMemberDtos;
using MilkyProject.DtoLayer.DTOs.UITestimonialDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents
{
    public class _UITestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UITestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);

                return View(values);
            }
            return View(null);
        }
    }
}
