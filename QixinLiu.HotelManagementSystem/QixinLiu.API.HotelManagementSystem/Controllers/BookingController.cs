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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<IActionResult> ListBookings()
        {
            var lists = await _bookingService.ListAllBookings();

            if (!lists.Any()) return NotFound();

            return Ok(lists);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingById(id);

            if (booking == null)  return NotFound();
            
            return Ok(booking);
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> EditBooking([FromBody] BookingRequestModel model)
        {

            var sucess = await _bookingService.EditBooking(model);

            if (sucess) return Ok(model);

            return BadRequest();
        }

        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingRequestModel model)
        {
            var sucess = await _bookingService.AddBooking(model);

            if (sucess) return Ok(model);

            return BadRequest();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var sucess = await _bookingService.DeleteBooking(id);

            if (sucess) return Ok();

            return BadRequest();
        }

    }
}
