using ApplicationCore.Models;
using ApplicationCore.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QixinLiu.MVC.HotelManagementSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var lists = await _bookingService.ListAllBookings();

            //if (!lists.Any()) return View( );

            return View(lists);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingById(id);

            if (booking == null) return View();

            return View(booking);
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> EditBooking(int id, int? roomNO,
                    string? cName, string? address, string? phone,
                    string? email, DateTime? checkIn, int? totalPersons, 
                    int? bookingDays, decimal? advance)
        {

            var bookingModel = new BookingRequestModel
            {
                Id = id,
                RoomNO = roomNO,
                CName = cName,
                Address = address,
                Phone = phone,
                Email = email,
                CheckIn = checkIn,
                TotalPersons = totalPersons,
                BookingDays = bookingDays,
                Advance = advance
            };

            var sucess = await _bookingService.EditBooking(bookingModel);

            if (sucess) return RedirectToAction("SuccessPage", new {viewName = "Edit"});

            return View();
        }

        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddBooking(int? roomNO,
                    string? cName, string? address, string? phone,
                    string? email, DateTime? checkIn, int? totalPersons,
                    int? bookingDays, decimal? advance)
        {

            var bookingModel = new BookingRequestModel
            {
                RoomNO = roomNO,
                CName = cName,
                Address = address,
                Phone = phone,
                Email = email,
                CheckIn = checkIn,
                TotalPersons = totalPersons,
                BookingDays = bookingDays,
                Advance = advance
            };

            var sucess = await _bookingService.AddBooking(bookingModel);

            if (sucess) return RedirectToAction("SuccessPage", new { viewName = "Add" });

            return View();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var sucess = await _bookingService.DeleteBooking(id);

            if (sucess) return RedirectToAction("SuccessPage", "Home", new { viewName = "Delete" });

            return View();
        }

       
    }
}
