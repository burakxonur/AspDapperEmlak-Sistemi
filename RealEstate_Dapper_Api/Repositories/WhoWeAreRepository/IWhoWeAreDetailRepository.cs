using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public interface IWhoWeAreDetailRepository
	{
		Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreDetailAsync();
		void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
		void DeleteWhoWeAreDetail(int id);
		void UpdateWhoWeAreDetail(UpdateWhoWeAreDetail updateWhoWeAreDetail);
		Task<GetByIDWhoWeAreDetail> GetWhoWeAreDetail(int id);
	}
}
