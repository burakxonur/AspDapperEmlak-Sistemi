﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
	public class BottomGridRepository : IBottomGridRepository
	{
		private readonly Context _context;

		public BottomGridRepository(Context context)
		{
			_context = context;
		}

		public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
		{
			string query = "Insert into BottomGrid(Icon,Title,Description) values (@icon,@title,@description)";
			var parameters = new DynamicParameters();
			parameters.Add("@icon", createBottomGridDto.Icon);
			parameters.Add("@title", createBottomGridDto.Title);
			parameters.Add("@description", createBottomGridDto.Description);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteBottomGrid(int id)
		{
			string query = "Delete from BottomGrid where BottomGridID=@bottomGridID";
			var parameters = new DynamicParameters();
			parameters.Add("@bottomGridID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
		{
			string query = "Select * from BottomGrid";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultBottomGridDto>(query);
				return values.ToList();
			}
		}
		public async Task<GetBottomGridDto> GetBottomGrid(int id)
		{
			string query = "Select * From BottomGrid where BottomGridID=@bottomGridID";
			var parameters = new DynamicParameters();
			parameters.Add("@bottomGridID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
				return values;
			}
		}

		public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
		{
			string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description where BottomGridID=@BottomGridid";
			var parameters = new DynamicParameters();
			parameters.Add("@BottomGridid", updateBottomGridDto.BottomGridID);
			parameters.Add("@icon", updateBottomGridDto.Icon);
			parameters.Add("@title", updateBottomGridDto.Title);
			parameters.Add("@description", updateBottomGridDto.Description);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}