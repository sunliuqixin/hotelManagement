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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<IActionResult> ListRooms()
        {
            var rooms = await _roomService.ListRooms();
            if (!rooms.Any())
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomDetails(int id)
        {
            var room = await _roomService.GetRoomDetails(id);
            
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> EditRoom([FromBody]RoomRequestModel requestModel)
        {
            
            if(await _roomService.EditRoom(requestModel))
            {
                return Ok(requestModel);
            }

            return BadRequest();
            
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        
        public async Task<IActionResult> AddRoom(RoomRequestModel roomModel)
        {
            
            var sucess = await _roomService.AddRoom(roomModel);
            if(sucess) return Ok(roomModel);
            return BadRequest();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (await _roomService.DeleteRoom(id))
            {
                return Ok($"Room ID: {id} Deleted!" );
            }
            else
            {
                return BadRequest("Deleted Room failed");
            }
        }
    }
}
