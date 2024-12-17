using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

		public async Task<List<ResultProductAdvertListWithCategoryByEmployee>> GetAllProductAdvertByEmployeeListAsync(int id)
		{
			string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,type,Adress,DealOfTheDay from" +
				" Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeId=@employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("employeeId", id);
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultProductAdvertListWithCategoryByEmployee>(query,parameters);
				return values.ToList();
			}
		}

		public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var conntection = _context.CreateConnection())
            {
                var values = await conntection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,type,Adress,DealOfTheDay from" +
                " Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var conntection = _context.CreateConnection())
            {
                var values = await conntection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLastFiveProductWithCategory>> GetLastFiveProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product Inner Join Category\r\non Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var conntection = _context.CreateConnection())
            {
                var values = await conntection.QueryAsync<ResultLastFiveProductWithCategory>(query);
                return values.ToList();
            }
        }

		public async Task<List<ResultLastFiveProductWithCategory>> GetLastSaleFiveProductList()
		{
			string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product Inner Join Category\r\non Product.ProductCategory=Category.CategoryID Where Type='Satılık' Order By ProductID Desc";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultLastFiveProductWithCategory>(query);
				return values.ToList();
			}
		}

		public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@Productid";
            var parameters = new DynamicParameters();
            parameters.Add("@Productid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@Productid";
            var parameters = new DynamicParameters();
            parameters.Add("@Productid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
