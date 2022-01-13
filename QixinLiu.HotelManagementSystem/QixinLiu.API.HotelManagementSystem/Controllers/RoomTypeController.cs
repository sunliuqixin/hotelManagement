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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        // GET: api/RoomType
        [HttpGet]
        public async Task<IActionResult> ListRoomTypes()
        {
            var roomTypes = await _roomTypeService.ListRoomTypes();
            if (!roomTypes.Any()) return NotFound();
            return Ok(roomTypes);

        }

        // GET: api/RoomType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomType(int id)
        {
            var roomType = await _roomTypeService.GetRoomTypeById(id);

            if (roomType == null)
            {
                return NotFound();
            }

            return Ok(roomType);
        }

        // PUT: api/RoomType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> EditRoomType([FromBody]RoomTypeRequestModel model)
        {
            var success = await _roomTypeService.EditRoomType(model);
            if (success) return Ok(model);
            return BadRequest();
            
        }

        // POST: api/RoomType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddRoomType([FromBody] RoomTypeRequestModel roomType)
        {
            if(roomType == null) return NoContent();
            var success = await _roomTypeService.AddRoomType(roomType);
            if(success) return Ok(roomType);
            return BadRequest();
        }

        // DELETE: api/RoomType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var success = await _roomTypeService.DeleteRoomType(id);
            if (success) return Ok($"Room ID: {id} Deleted!");
            return BadRequest();
        }

    }
}
