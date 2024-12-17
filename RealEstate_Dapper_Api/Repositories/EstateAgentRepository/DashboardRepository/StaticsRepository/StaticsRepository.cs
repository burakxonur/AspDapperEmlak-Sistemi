using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StaticsRepository
{
	public class StaticsRepository : IStaticsRepository
	{
		private readonly Context _context;

		public StaticsRepository(Context context)
		{
			_context = context;
		}

		public int AllProductCount()
		{
			string query = "Select count(*) from Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ProductCountByEmployeeId(int id)
		{
			string query = "Select count(*) from Product where EmployeeId=@employeeid";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeid", id);
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query,parameters);
				return values;
			}
		}

		public int ProductCountByStatusFalse(int id)
		{
			string query = "Select count(*) from Product where EmployeeId=@employeeid and ProductStatus=0";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeid", id);
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query, parameters);
				return values;
			}
		}

		public int ProductCountByStatusTrue(int id)
		{
			string query = "Select count(*) from Product where EmployeeId=@employeeid and ProductStatus=1";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeid", id);
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query, parameters);
				return values;
			}
		}
	}
}
