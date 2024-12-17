using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
	public class MessageRepository : IMessageRepository
	{
		private readonly Context _context;

		public MessageRepository(Context context)
		{
			_context = context;
		}

		public async Task<List<ResultInboxMessageDto>> GetInboxLastThereMessageListByReceiver(int id)
		{
			string query = "Select top(3) MessageID,Name,Subject,Detail,SendDate,IsRead,UserImageUrl From Message inner join AppUser on Message.Sender=AppUser.UserId where Receiver=@receieverid order by MessageID desc";
			var parameters = new DynamicParameters();
			parameters.Add("@receieverid", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
				return values.ToList();
			}
		}
	}
}
