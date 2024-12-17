using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var values = await _productRepository.GetAllProductAsync();
			return Ok(values);
		}
		[HttpGet("ProductListWithCategory")]
		public async Task<IActionResult> ProductListWithCategory()
		{
			var values = await _productRepository.GetAllProductWithCategoryAsync();
			return Ok(values);
		}
		[HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
		public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
		{
			_productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
			return Ok("Fırsatlar Durumu Aktif Yapıldı.");
		}
		[HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
		public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
		{
			_productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
			return Ok("Fırsatlar Durumu Pasif Yapıldı.");
		}
		[HttpGet("LastFiveProductList")]
        public async Task<IActionResult> LastFiveProductList()
        {
            var values = await _productRepository.GetLastFiveProductAsync();
            return Ok(values);
        }
		[HttpGet("GetLastSaleFiveProductList")]
		public async Task<IActionResult> GetLastSaleFiveProductList()
		{
			var values = await _productRepository.GetLastSaleFiveProductList();
			return Ok(values);
		}
		[HttpGet("ProductAdvertsListEmployee")]
		public async Task<IActionResult> ProductAdvertsListEmployee(int id)
		{
			var values=await _productRepository.GetAllProductAdvertByEmployeeListAsync(id);
			return Ok(values);
		}
	}
}
