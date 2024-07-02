﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MilkyProject.DtoLayer.DTOs.UISliderDtos;

namespace MilkyProject.WebUI.ViewComponents
{
    public class _UISliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UISliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7159/api/Slider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                
                return View(values);
            }
            return View(null);
        }
    }
}
