﻿namespace RealEstate_Dapper_UI.Dtos.ToDoListDtos
{
	public class UpdateToDoListDto
	{
		public int ToDoListID { get; set; }
		public string Description { get; set; }
		public string ToDoListStatus { get; set; }
	}
}
