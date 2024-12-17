using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoListController : ControllerBase
	{
		private readonly IToDoListRepository _toDoListRepository;

		public ToDoListController(IToDoListRepository toDoListRepository)
		{
			_toDoListRepository = toDoListRepository;
		}
		[HttpGet]
		public async Task<IActionResult> ToDoList()
		{
			var values = await _toDoListRepository.GetAllToDoListAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateToDoList(CreateToDoListDto createToDoListDto)
		{
			_toDoListRepository.CreateToDoList(createToDoListDto);
			return Ok("Günlük Yapılacaklar Listesi Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteToDoList(int id)
		{
			_toDoListRepository.DeleteToDoList(id);
			return Ok("Günlük Yapılacaklar Listesi Başarılı Bir Şekilde Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
		{
			_toDoListRepository.UpdateToDoList(updateToDoListDto);
			return Ok("Günlük Yapılacaklar Listesi Başarılı Bir Şekilde Güncellenmiştir.");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetToDoList(int id)
		{
			var values = await _toDoListRepository.GetToDoList(id);
			return Ok(values);
		}
	}
}
