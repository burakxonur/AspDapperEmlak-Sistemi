﻿using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly Context _context;

		public CategoryRepository(Context context)
		{
			_context = context;
		}

		public async void CreateCategory(CreateCategoryDto categoryDto)
		{
			string query = "Insert into Category(CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryName", categoryDto.CategoryName);
			parameters.Add("@categoryStatus", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void DeleteCategory(int id)
		{
			string query = "Delete from Category where CategoryID=@categoryID";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
		{
			string query = "Select * from Category";
			using (var conntection = _context.CreateConnection())
			{
				var values = await conntection.QueryAsync<ResultCategoryDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDCategoryDto> GetCategory(int id)
		{
			string query = "Select * From Category where CategoryID=@categoryID";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
				return values;
			}
		}

		public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryID", updateCategoryDto.CategoryID);
			parameters.Add("@categoryName", updateCategoryDto.CategoryName);
			parameters.Add("@categoryStatus", updateCategoryDto.CategoryStatus);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
