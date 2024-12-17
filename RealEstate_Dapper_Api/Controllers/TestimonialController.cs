﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialRepository _testimonialRepository;

		public TestimonialController(ITestimonialRepository testimonialRepository)
		{
			_testimonialRepository = testimonialRepository;
		}
		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _testimonialRepository.GetAllTestimonialAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			_testimonialRepository.CreateTestimonial(createTestimonialDto);
			return Ok("Yorum Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			_testimonialRepository.DeleteTestimonial(id);
			return Ok("Yorum Başarılı Bir Şekilde Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialRepository.UpdateTestimonial(updateTestimonialDto);
			return Ok("Yorum Başarılı Bir Şekilde Güncellenmiştir.");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTestimonial(int id)
		{
			var values = await _testimonialRepository.GetTestimonial(id);
			return Ok(values);
		}
	}
}