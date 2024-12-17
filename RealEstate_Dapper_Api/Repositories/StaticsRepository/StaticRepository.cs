using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StaticsRepository
{
	public class StaticRepository : IStaticRepository
	{
		private readonly Context _context;

		public StaticRepository(Context context)
		{
			_context = context;
		}
		public int ActiveCategoryCount()
		{
			string query = "Select Count(*) From Category where CategoryStatus=1";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ActiveEmployeeCount()
		{
			string query = "Select Count(*) From Employee where Status=1";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ApartmentCount()
		{
			string query = "Select Count(*) From Product where Title like '%Daire%'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public decimal AveRageProductPriceByRent()
		{
			string query = "Select Avg(Price) From Product where type='Kiralık'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public decimal AveRageProductPriceBySale()
		{
			string query = "Select Avg(Price) From Product where type = 'Satılık'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public int AverageRoomCount()
		{
			string query = "Select Avg(RoomCount)from ProductDetails";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int CategoryCount()
		{
			string query = "Select count(*)from Category";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string CategoryNameByMaxProductCount()
		{
			string query = "Select top(1) CategoryName,COUNT(*) from Product inner join Category on Product.ProductCategory=Category.CategoryID Group by CategoryName Order by Count(*) desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string CityNameByMaxProductCount()
		{
			string query = "Select top(1) city,count(*) as 'İlan Sayısı' from Product group by City order by City asc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int DiffrentCityCount()
		{
			string query = "SELECT COUNT( Distinct(city)) FROM Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string EmpolyeeNameByMaxProductCount()
		{
			string query = "SELECT Name,count(*) from Product inner join Employee on Product.EmployeeID=Employee.EmployeeID  group by name";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public decimal LastProductPrice()
		{
			string query = "SELECT Max(Price)FROM Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public string NewestBuildYear()
		{
			string query = "SELECT MAX(BuildYear)from ProductDetails";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string OldestBuildYear()
		{
			string query = "SELECT min(BuildYear)from ProductDetails";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int PassiveCategoryCount()
		{
			string query = "SELECT COUNT(*) from category where CategoryStatus='0'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ProductCount()
		{
			string query = "SELECT COUNT(*) from Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}
	}
}
