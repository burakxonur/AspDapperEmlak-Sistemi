using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Service;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginServices _loginServices;

		public EmployeeController(IHttpClientFactory httpClientFactory, ILoginServices loginServices)
		{
			_httpClientFactory = httpClientFactory;
			_loginServices = loginServices;
		}

		public async Task<IActionResult> Index()
		{
			var user = User.Claims;
			var userid = _loginServices.GetUserId;

			var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("https://localhost:44346/api/Employee");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
					return View(values);
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateEmployee()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			var cliet = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createEmployeeDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await cliet.PostAsync("https://localhost:44346/api/Employee", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/Employee/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateEmployee(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44346/api/Employee/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateEmployeeDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44346/api/Employee/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
