﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Service;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _NavBarLastThreeMessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginServices _loginServices;

        public _NavBarLastThreeMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginServices loginServices)
        {
            _httpClientFactory = httpClientFactory;
            _loginServices = loginServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginServices.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Products/Message?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

