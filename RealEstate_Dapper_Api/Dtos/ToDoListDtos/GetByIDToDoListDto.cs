﻿namespace RealEstate_Dapper_Api.Dtos.ToDoListDtos
{
	public class GetByIDToDoListDto
	{
		public int ToDoListID { get; set; }
		public string Description { get; set; }
		public string ToDoListStatus { get; set; }
	}
}
