using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactRepository _contactRepository;

		public ContactController(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}
		[HttpGet("GetAllContactAsync")]
		public async Task<IActionResult> GetAllContactAsync()
		{
			var values = await _contactRepository.GetAllContactAsync();
			return Ok(values);
		}
		[HttpGet("GetLastFourContactResult")]
		public async Task<IActionResult> GetLastFourContactResult()
		{
			var values = await _contactRepository.GetLastFourContactResult();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			_contactRepository.CreateContact(createContactDto);
			return Ok("Mesaj Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(int id)
		{
			_contactRepository.DeleteContact(id);
			return Ok("Mesaj Başarılı Bir Şekilde Silindi.");
		}
	}
}
