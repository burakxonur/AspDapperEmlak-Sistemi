using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
	public interface IPopularLocationRepository
	{
		Task<List<ResultPopularLocationDto>> GetAllPopularAsync();
		void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
		void DeletePopularLocation(int id);
		void UpdatePopularLocation(UpdatePopularLocation updatePopularLocation);
		Task<GetByIDPopluarLocation> GetPopularLocation(int id);
	}
}
