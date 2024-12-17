using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopularLocationController : ControllerBase
	{
		private readonly IPopularLocationRepository _popularLocationRepository;

		public PopularLocationController(IPopularLocationRepository popularLocationRepository)
		{
			_popularLocationRepository = popularLocationRepository;
		}
		[HttpGet]
		public async Task<IActionResult> PoularLocationList()
		{
			var values = await _popularLocationRepository.GetAllPopularAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocation)
		{
			_popularLocationRepository.CreatePopularLocation(createPopularLocation);
			return Ok("Lokasyon Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeletePopularLocation(int id)
		{
			_popularLocationRepository.DeletePopularLocation(id);
			return Ok("Lokasyon Başarılı Bir Şekilde Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocation updatePopularLocation)
		{
			_popularLocationRepository.UpdatePopularLocation(updatePopularLocation);
			return Ok("Lokasyon Başarılı Bir Şekilde Güncellenmiştir.");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetPopularLocation(int id)
		{
			var values = await _popularLocationRepository.GetPopularLocation(id);
			return Ok(values);
		}
	}
}
