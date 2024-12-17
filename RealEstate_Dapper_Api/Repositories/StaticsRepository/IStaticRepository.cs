namespace RealEstate_Dapper_Api.Repositories.StaticsRepository
{
	public interface IStaticRepository
	{
		int CategoryCount();
		int ActiveCategoryCount();
		int PassiveCategoryCount();
		int ProductCount();
		int ApartmentCount();
		string EmpolyeeNameByMaxProductCount();
		string CategoryNameByMaxProductCount();
		decimal AveRageProductPriceByRent();
		decimal AveRageProductPriceBySale();
		string CityNameByMaxProductCount();
		int DiffrentCityCount();
		decimal LastProductPrice();
		string NewestBuildYear();
		string OldestBuildYear();
		int AverageRoomCount();
		int ActiveEmployeeCount();

	}
}
