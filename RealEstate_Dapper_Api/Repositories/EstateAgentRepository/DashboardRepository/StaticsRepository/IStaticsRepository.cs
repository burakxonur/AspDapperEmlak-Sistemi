namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StaticsRepository
{
	public interface IStaticsRepository
	{
		int ProductCountByEmployeeId(int id);
		int ProductCountByStatusTrue(int id);
		int ProductCountByStatusFalse(int id);
		int AllProductCount();
	}
}
