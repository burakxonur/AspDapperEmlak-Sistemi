﻿using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
	public interface IProductRepository
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task<List<ResultProductAdvertListWithCategoryByEmployee>> GetAllProductAdvertByEmployeeListAsync(int id);
		Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		void ProductDealOfTheDayStatusChangeToTrue(int id);
		void ProductDealOfTheDayStatusChangeToFalse(int id);
		Task<List<ResultLastFiveProductWithCategory>> GetLastFiveProductAsync();
		Task<List<ResultLastFiveProductWithCategory>> GetLastSaleFiveProductList();


    }
}
