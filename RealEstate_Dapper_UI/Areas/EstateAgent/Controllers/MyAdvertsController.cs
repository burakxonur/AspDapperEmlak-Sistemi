using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Service;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginServices _loginServices;

		public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginServices loginServices)
		{
			_httpClientFactory = httpClientFactory;
			_loginServices = loginServices;
		}
		public async Task<IActionResult> Index()
		{
			var id = _loginServices.GetUserId;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44346/api/Products/ProductAdvertsListEmployee?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployee>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
