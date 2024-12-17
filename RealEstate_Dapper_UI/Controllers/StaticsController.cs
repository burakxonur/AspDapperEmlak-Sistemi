using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
	public class StaticsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public StaticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
            #region İstatistik 1
            var client =_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44346/api/Statics/ActiveCategoryCount");
			var jsonData=await responseMessage.Content.ReadAsStringAsync();
			ViewBag.activecategorycount = jsonData;
            #endregion

            #region İstatistik 2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:44346/api/Statics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeemployeecount = jsonData2;
            #endregion

            #region İstatistik 3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync("https://localhost:44346/api/Statics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentcount = jsonData3;
            #endregion

            #region İstatistik 4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client.GetAsync("https://localhost:44346/api/Statics/AveRageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.aveRageProductPriceByRent = jsonData4;
            #endregion

            #region İstatistik 5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client.GetAsync("https://localhost:44346/api/Statics/AveRageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.AveRageProductPriceBySale = jsonData5;
            #endregion

            #region İstatistik 6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client.GetAsync("https://localhost:44346/api/Statics/AverageRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount = jsonData6;
            #endregion

            #region İstatistik 7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client.GetAsync("https://localhost:44346/api/Statics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData7;
            #endregion

            #region İstatistik 8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client.GetAsync("https://localhost:44346/api/Statics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData8;
            #endregion

            #region İstatistik 9
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client.GetAsync("https://localhost:44346/api/Statics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonData9;
            #endregion

            #region İstatistik 10
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client.GetAsync("https://localhost:44346/api/Statics/DiffrentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.DiffrentCityCount = jsonData10;
            #endregion

            #region İstatistik 11
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client.GetAsync("https://localhost:44346/api/Statics/EmpolyeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmpolyeeNameByMaxProductCount = jsonData11;
            #endregion

            #region İstatistik 12
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client.GetAsync("https://localhost:44346/api/Statics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData12;
            #endregion

            #region İstatistik 13
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client.GetAsync("https://localhost:44346/api/Statics/NewestBuildYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.NewestBuildYear = jsonData13;
            #endregion

            #region İstatistik 14
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client.GetAsync("https://localhost:44346/api/Statics/PassiveCategoryCount");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonData14;
            #endregion

            #region İstatistik 15
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:44346/api/Statics/ProductCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData15;
            #endregion






            return View();
		}
	}
}
