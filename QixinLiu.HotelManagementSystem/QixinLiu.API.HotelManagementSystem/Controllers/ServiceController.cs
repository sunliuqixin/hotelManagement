using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using infrastructure.Data;
using ApplicationCore.ServicesInterfaces;
using ApplicationCore.Models;

namespace QixinLiu.API.HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<IActionResult> ListAllServices()
        {
            var services = await _serviceService.ListAllServices();
            return Ok(services);
        }

        // GET: api/Service
        [HttpGet]
        [Route("GetService")]
        public async Task<IActionResult> GetService([FromQuery]int id)
        {
            var service = await _serviceService.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/Service/5
        [HttpPut]
        public async Task<IActionResult> PutService([FromQuery] int id, [FromBody]ServiceRequestModel model)
        {


            bool success = await _serviceService.EditService(model);

            if (success) return Ok();

            return BadRequest("Edit Failed!");
        }

        // POST: api/Service
        [HttpPost]
        public async Task<IActionResult> PostService([FromBody] ServiceRequestModel model)
        {
            bool success = await _serviceService.AddService(model);
            if (success) return Ok();

            return BadRequest("Add Failed!");
        }

        // DELETE: api/Service/5
        [HttpDelete]
        public async Task<IActionResult> DeleteService([FromQuery] int id)
        {
            bool success = await _serviceService.DeleteService(id);
            if (success) return Ok();

            return BadRequest("Delete Failed!");
        }

    }
}
