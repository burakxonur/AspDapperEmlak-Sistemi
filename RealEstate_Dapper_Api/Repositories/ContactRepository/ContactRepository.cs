using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
	public class ContactRepository : IContactRepository
	{
		private readonly Context _context;

		public ContactRepository(Context context)
		{
			_context = context;
		}

		public async void CreateContact(CreateContactDto createContactDto)
		{
			string query = "Insert into Contact(Name,Subject,Email,Message,SendDate) values (@name,@subject,@mail,@message,@sendDate)";
			var parameters = new DynamicParameters();
			parameters.Add("@name", createContactDto.Name);
			parameters.Add("@subject", createContactDto.Subject);
			parameters.Add("@mail", createContactDto.Email);
			parameters.Add("@message", createContactDto.Message);
			parameters.Add("@sendDate", createContactDto.SendDate.ToString("dd-MM-yyyy"));
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteContact(int id)
		{
			string query = "Delete from Contact where ContactID=@contactID";
			var parameters = new DynamicParameters();
			parameters.Add("@contactID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultContactDto>> GetAllContactAsync()
		{
			string query = "Select * from Contact";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultContactDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDContactDto> GetContact(int id)
		{
			string query = "Select * From Contact where ContactID=@contactID";
			var parameters = new DynamicParameters();
			parameters.Add("@contactID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
				return values;
			}
		}

		public async Task<List<LastFourContactResultDto>> GetLastFourContactResult()
		{
			string query = "Select Top(4) * from Contact order by ContactID Desc";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<LastFourContactResultDto>(query);
				return values.ToList();
			}
		}
	}
}
