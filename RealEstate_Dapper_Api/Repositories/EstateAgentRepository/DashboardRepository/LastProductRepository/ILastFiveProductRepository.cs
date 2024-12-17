using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository
{
    public interface ILastFiveProductRepository
    {
        Task<List<ResultLastFiveProductWithCategory>> GetLastFiveProductAsync(int id);
    }
}
