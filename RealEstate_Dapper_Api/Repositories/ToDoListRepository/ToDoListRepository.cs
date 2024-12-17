using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
	public class ToDoListRepository : IToDoListRepository
	{
		private readonly Context _context;

		public ToDoListRepository(Context context)
		{
			_context = context;
		}

		public async void CreateToDoList(CreateToDoListDto createToDoList)
		{
			string query = "Insert into ToDoList(Description,ToDoListStatus) values (@description,@toDoListStatus)";
			var parameters = new DynamicParameters();
			parameters.Add("@description", createToDoList.Description);
			parameters.Add("@toDoListStatus", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteToDoList(int id)
		{
			string query = "Delete from ToDoList where ToDoListID=@toDoListID";
			var parameters = new DynamicParameters();
			parameters.Add("@toDoListID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
		{
			string query = "Select * from ToDoList";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultToDoListDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDToDoListDto> GetToDoList(int id)
		{
			string query = "Select * From ToDoList where ToDoListID=@toDoListID";
			var parameters = new DynamicParameters();
			parameters.Add("@toDoListID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
				return values;
			}
		}

		public async void UpdateToDoList(UpdateToDoListDto updateToDoListDto)
		{
			string query = "Update ToDoList Set Description=@description,ToDoListStatus=@toDoListStatus where ToDoListID=@toDoListID";
			var parameters = new DynamicParameters();
			parameters.Add("@toDoListID", updateToDoListDto.ToDoListID);
			parameters.Add("@description", updateToDoListDto.Description);
			parameters.Add("@toDoListStatus", updateToDoListDto.ToDoListStatus);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
