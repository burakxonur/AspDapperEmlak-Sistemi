using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
	{
		private readonly Context _context;
		public WhoWeAreDetailRepository(Context context)
		{
			_context = context;
		}
		public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
		{
			string query = "Insert into WhoWeAreDetail(Title,SubTitle,Description1,Description2) values (@title,@subTitle,@description1,@description2)";
			var parameters = new DynamicParameters();
			parameters.Add("@title", createWhoWeAreDetailDto.Title);
			parameters.Add("@subTitle", createWhoWeAreDetailDto.SubTitle);
			parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
			parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteWhoWeAreDetail(int id)
		{
			string query = "Delete from WhoWeAreDetail where WhoWeAreDetailID=@WhoWeAreDetailID";
			var parameters = new DynamicParameters();
			parameters.Add("@WhoWeAreDetailID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreDetailAsync()
		{
			string query = "Select * from WhoWeAreDetail";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultWhoWeAreDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDWhoWeAreDetail> GetWhoWeAreDetail(int id)
		{
			string query = "Select * From WhoWeAreDetail where WhoWeAreDetailID=@WhoWeAreDetailID";
			var parameters = new DynamicParameters();
			parameters.Add("@WhoWeAreDetailID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetail>(query, parameters);
				return values;
			}
		}

		public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetail updateWhoWeAreDetail)
		{
			string query = "Update WhoWeAreDetail Set Title=@Title,SubTitle=@SubTitle,Description1=@Description1,Description2=@Description2 where WhoWeAreDetailID=@WhoWeAreDetailID";
			var parameters = new DynamicParameters();
			parameters.Add("@WhoWeAreDetailID", updateWhoWeAreDetail.WhoWeAreDetailID);
			parameters.Add("@Title", updateWhoWeAreDetail.Title);
			parameters.Add("@SubTitle", updateWhoWeAreDetail.SubTitle);
			parameters.Add("@Description1", updateWhoWeAreDetail.Description1);
			parameters.Add("@Description2", updateWhoWeAreDetail.Description2);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
