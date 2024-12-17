﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }
		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
		{
			_serviceRepository.CreateService(createServiceDto);
			return Ok("Hizmet Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteService(int id)
		{
			_serviceRepository.DeleteService(id);
			return Ok("Hizmet Başarılı Bir Şekilde Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
		{
			_serviceRepository.UpdateService(updateServiceDto);
			return Ok("Hizmet Başarılı Bir Şekilde Güncellenmiştir.");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetService(int id)
		{
			var values = await _serviceRepository.GetService(id);
			return Ok(values);
		}
	}
}