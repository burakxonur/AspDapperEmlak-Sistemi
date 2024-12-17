using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
	public class PopularLocation:IPopularLocationRepository
	{
		private readonly Context _context;

		public PopularLocation(Context context)
		{
			_context = context;
		}

		public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			string query = "Insert into PopularLocation(CityName,ImageUrl) values (@cityName,@imaUrl)";
			var parameters = new DynamicParameters();
			parameters.Add("@cityName", createPopularLocationDto.CityName);
			parameters.Add("@imaUrl", createPopularLocationDto.ImageUrl);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeletePopularLocation(int id)
		{
			string query = "Delete from PopularLocation where LocationID=@locationID";
			var parameters = new DynamicParameters();
			parameters.Add("locationID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultPopularLocationDto>> GetAllPopularAsync()
		{
			string query = "Select * from PopularLocation";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultPopularLocationDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDPopluarLocation> GetPopularLocation(int id)
		{
			string query = "Select * From PopularLocation where LocationID=@locationID";
			var parameters = new DynamicParameters();
			parameters.Add("@locationID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopluarLocation>(query, parameters);
				return values;
			}
		}

		public async void UpdatePopularLocation(UpdatePopularLocation updatePopularLocation)
		{
			string query = "Update PopularLocation set CityName=@cityName,ImageUrl=@imageUrl where LocationID=@locationID";
			var parameters =new DynamicParameters();
			parameters.Add("locationID", updatePopularLocation.LocationID);
			parameters.Add("cityName", updatePopularLocation.CityName);
			parameters.Add("imageUrl", updatePopularLocation.ImageUrl);
			using (var connection = _context.CreateConnection())
			{
				var values=await connection.QueryFirstOrDefaultAsync<UpdatePopularLocation>(query, parameters);
				
			}
		}
	}
}
