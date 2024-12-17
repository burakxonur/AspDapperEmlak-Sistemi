using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Service;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
	public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginServices _loginServices;

		public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginServices loginServices)
		{
			_httpClientFactory = httpClientFactory;
			_loginServices = loginServices;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var id = _loginServices.GetUserId;
			#region İstatistik 1 -ToplamİlanSayısı
			var client11 = _httpClientFactory.CreateClient();
			var responseMessage11 = await client11.GetAsync("https://localhost:44346/api/EstateAgentDashboarStatics/AllProductCount");
			var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
			ViewBag.ProductCount = jsonData11;
			#endregion

			#region İstatistik 2 - KulToplamİlanSay
			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:44346/api/EstateAgentDashboarStatics/ProductCountByEmployeeId?id="+id);
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); 
			ViewBag.EmployeeByProductCount = jsonData2;
			#endregion

			#region İstatistik3 -AktifİlanSay
			var client3 = _httpClientFactory.CreateClient();
			var responseMessage3 = await client3.GetAsync("https://localhost:44346/api/EstateAgentDashboarStatics/ProductCountByStatusTrue?id=" + id);
			var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
			ViewBag.ActiveProductCount = jsonData3;
			#endregion

			#region İstatistik4 -PasifİlanSay
			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:44346/api/EstateAgentDashboarStatics/ProductCountByStatusFalse?id=" + id);
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
			ViewBag.PasiveProductCount = jsonData4;
			#endregion

			return View();
		}
	}
}
