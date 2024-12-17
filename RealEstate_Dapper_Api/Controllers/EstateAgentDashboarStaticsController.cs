using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StaticsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstateAgentDashboarStaticsController : ControllerBase
	{
		private readonly IStaticsRepository _staticsRepository;

		public EstateAgentDashboarStaticsController(IStaticsRepository staticsRepository)
		{
			_staticsRepository = staticsRepository;
		}
		[HttpGet("ProductCountByEmployeeId")]
		public IActionResult ProductCountByEmployeeId(int id)
		{
			return Ok(_staticsRepository.ProductCountByEmployeeId(id));
		}
		[HttpGet("ProductCountByStatusTrue")]
		public IActionResult ProductCountByStatusTrue(int id)
		{
			return Ok(_staticsRepository.ProductCountByStatusTrue(id));
		}
		[HttpGet("ProductCountByStatusFalse")]
		public IActionResult ProductCountByStatusFalse(int id)
		{
			return Ok(_staticsRepository.ProductCountByStatusFalse(id));
		}
		[HttpGet("AllProductCount")]
		public IActionResult AllProductCount()
		{
			return Ok(_staticsRepository.AllProductCount());
		}
	}
}
