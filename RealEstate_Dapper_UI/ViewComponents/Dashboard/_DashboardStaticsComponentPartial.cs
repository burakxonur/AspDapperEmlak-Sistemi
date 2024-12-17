using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardStaticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardStaticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			#region İstatistik 1 -ToplamİlanSayısı
			var client11 = _httpClientFactory.CreateClient();
			var responseMessage11 = await client11.GetAsync("https://localhost:44346/api/Statics/ProductCount");
			var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
			ViewBag.ProductCount = jsonData11;
			#endregion

			#region İstatistik 2 - EnBasarisiliPersonel
			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:44346/api/Statics/EmpolyeeNameByMaxProductCount");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.EmpolyeeNameByMaxProductCount = jsonData2;
			#endregion

			#region İstatistik3 -FarklıŞehirİlanVar
			var client3 = _httpClientFactory.CreateClient();
			var responseMessage3 = await client3.GetAsync("https://localhost:44346/api/Statics/DiffrentCityCount");
			var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
			ViewBag.DiffrentCityCount = jsonData3;
			#endregion

			#region İstatistik4 -AktifPersonelSayısı
			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:44346/api/Statics/ActiveEmployeeCount");
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
			ViewBag.activeemployeecount = jsonData4;
			#endregion

			return View();
		}
	}
}
