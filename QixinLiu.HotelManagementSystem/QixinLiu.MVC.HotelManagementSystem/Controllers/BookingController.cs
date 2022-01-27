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

        [HttpGet]
        public async Task<IActionResult> AllBookings()
            {
            var lists = await _bookingService.ListAllBookings();

            if (!lists.Any()) return View( );

            return View(lists);
        }

        [HttpGet]
        [Route("Booking/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingById(id);

            if (booking == null) return View();

            return View(booking);
        }


        [HttpGet]
        public async Task<IActionResult> Book(int id)
        {
            BookingResponseModel booking;
            if (id != -1)
            {
                booking = await _bookingService.GetBookingById(id);
            }
            else
            {
                booking = new BookingResponseModel
                {
                    Id = -1,
                    RoomNO = 1,
                    CName = "Customer Name",
                    Address = "Customer Address",
                    Phone = "999-999-9999",
                    Email = "CustomerEmail@mail.com",
                    CheckIn = DateTime.Now,
                    TotalPersons = 1,
                    BookingDays = 1,
                    Advance = 0
                };
            }

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Book(int id, int? roomNO,
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

            if (id != -1)
            {
                bookingModel.Id = id;

                var sucess = await _bookingService.EditBooking(bookingModel);

                if (sucess) return RedirectToAction("SuccessPage", 
                    "Home", new { viewName = "Edit Booking" }); 
            }
            else
            {
                var sucess = await _bookingService.AddBooking(bookingModel);

                if (sucess) return RedirectToAction("SuccessPage", 
                    "Home", new { viewName = "Add Booking" });
            }

            return View();

        }

 
        [HttpPost]
        [Route("Booking/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucess = await _bookingService.DeleteBooking(id);

            if (sucess) return RedirectToAction("SuccessPage", 
                "Home", new { viewName = "Delete Booking" });

            return View();
        }
  
    }
}
