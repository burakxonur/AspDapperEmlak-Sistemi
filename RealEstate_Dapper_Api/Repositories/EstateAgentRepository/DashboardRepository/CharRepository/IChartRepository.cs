using RealEstate_Dapper_Api.Dtos.ChartDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.CharRepository
{
	public interface IChartRepository
	{
		Task<List<ResultChartDto>> GetFiveCityForChart();
	}
}
