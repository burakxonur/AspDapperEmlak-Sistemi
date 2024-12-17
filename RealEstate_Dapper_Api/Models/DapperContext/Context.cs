using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
	public class Context
	{
		private readonly IConfiguration _configuration;
		private readonly string _ConnectionString;
		public Context(IConfiguration configuration)
		{
			_configuration = configuration;
			_ConnectionString = _configuration.GetConnectionString("connection");
		}
		public IDbConnection CreateConnection() => new SqlConnection(_ConnectionString);

	}
}
