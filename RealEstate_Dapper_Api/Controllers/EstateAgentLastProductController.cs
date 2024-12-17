using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductController : ControllerBase
    {
        private readonly ILastFiveProductRepository _lastFiveProductRepository;

        public EstateAgentLastProductController(ILastFiveProductRepository lastFiveProductRepository)
        {
            _lastFiveProductRepository = lastFiveProductRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetLastFiveProductAsync(int id)
        {
            var values = await _lastFiveProductRepository.GetLastFiveProductAsync(id);
            return Ok(values);
        }
    }
}
