using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository
{
    public class LastFiveProductRepository : ILastFiveProductRepository
    {
        private readonly Context _context;

        public LastFiveProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLastFiveProductWithCategory>> GetLastFiveProductAsync(int id)
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("employeeID", id);
            using (var conntection = _context.CreateConnection())
            {
                var values = await conntection.QueryAsync<ResultLastFiveProductWithCategory>(query,parameters);
                return values.ToList();
            }
        }
    }
}
