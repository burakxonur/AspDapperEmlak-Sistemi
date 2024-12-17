using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StaticsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaticsController : ControllerBase
	{
		private readonly IStaticRepository _staticRepository;

		public StaticsController(IStaticRepository staticRepository)
		{
			_staticRepository = staticRepository;
		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_staticRepository.ActiveCategoryCount());
		}
		[HttpGet("ActiveEmployeeCount")]
		public IActionResult ActiveEmployeeCount()
		{
			return Ok(_staticRepository.ActiveEmployeeCount());
		}
		[HttpGet("ApartmentCount")]
		public IActionResult ApartmentCount()
		{
			return Ok(_staticRepository.ApartmentCount());
		}
		[HttpGet("AveRageProductPriceByRent")]
		public IActionResult AveRageProductPriceByRent()
		{
			return Ok(_staticRepository.AveRageProductPriceByRent());
		}
		[HttpGet("AveRageProductPriceBySale")]
		public IActionResult AveRageProductPriceBySale()
		{
			return Ok(_staticRepository.AveRageProductPriceBySale());
		}
		[HttpGet("AverageRoomCount")]
		public IActionResult AverageRoomCount()
		{
			return Ok(_staticRepository.AverageRoomCount());
		}
		[HttpGet("CategoryCount")]
		public IActionResult CategoryCount()
		{
			return Ok(_staticRepository.CategoryCount());
		}
		[HttpGet("CategoryNameByMaxProductCount")]
		public IActionResult CategoryNameByMaxProductCount()
		{
			return Ok(_staticRepository.CategoryNameByMaxProductCount());
		}
		[HttpGet("CityNameByMaxProductCount")]
		public IActionResult CityNameByMaxProductCount()
		{
			return Ok(_staticRepository.CityNameByMaxProductCount());
		}
		[HttpGet("DiffrentCityCount")]
		public IActionResult DiffrentCityCount()
		{
			return Ok(_staticRepository.DiffrentCityCount());
		}
		[HttpGet("EmpolyeeNameByMaxProductCount")]
		public IActionResult EmpolyeeNameByMaxProductCount()
		{
			return Ok(_staticRepository.EmpolyeeNameByMaxProductCount());
		}
		[HttpGet("LastProductPrice")]
		public IActionResult LastProductPrice()
		{
			return Ok(_staticRepository.LastProductPrice());
		}
		[HttpGet("NewestBuildYear")]
		public IActionResult NewestBuildYear()
		{
			return Ok(_staticRepository.NewestBuildYear());
		}
		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			return Ok(_staticRepository.PassiveCategoryCount());
		}
		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_staticRepository.ProductCount());
		}
	}
}
