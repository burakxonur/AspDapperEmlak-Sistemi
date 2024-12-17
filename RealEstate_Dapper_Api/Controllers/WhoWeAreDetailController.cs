using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WhoWeAreDetailController : ControllerBase
	{
		private readonly IWhoWeAreDetailRepository _whoWeAreRepository;

		public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreRepository)
		{
			_whoWeAreRepository = whoWeAreRepository;
		}
		[HttpGet]
		public async Task<IActionResult> WhoWeAreDetail()
		{
			var values = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
		{
			_whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
			return Ok("Hakkımıda Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
		{
			_whoWeAreRepository.DeleteWhoWeAreDetail(id);
			return Ok("Hakkımıda Başarılı Bir Şekilde Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetail updateWhoWeAreDetail)
		{
			_whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetail);
			return Ok("Hakkımıda Başarılı Bir Şekilde Güncellenmiştir.");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetWhoWeAreDetail(int id)
		{
			var values = await _whoWeAreRepository.GetWhoWeAreDetail(id);
			return Ok(values);
		}
	}
}
