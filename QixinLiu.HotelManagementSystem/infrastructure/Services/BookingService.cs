using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.RepositoryIntetfaces;
using ApplicationCore.ServicesInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        protected readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        public async Task<bool> AddBooking(BookingRequestModel booking)
        {
            if(booking == null) return false;
 
            var newBooking = new Booking
            {
                RoomNO = booking.RoomNO,
                CName = booking.CName,
                Address = booking.Address,
                Phone = booking.Phone,
                Email = booking.Email,
                CheckIn = booking.CheckIn,
                TotalPersons = booking.TotalPersons,
                BookingDays = booking.BookingDays,
                Advance = booking.Advance
            };

            var added = await _bookingRepository.AddAsync(newBooking);
            if (added != null) return true;

            Console.WriteLine("Add Booking Failed!");
            return false;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            
            var deleteBooking = await _bookingRepository.GetByIdAsync(id);
            if (deleteBooking == null)
            {
                Console.WriteLine($"ID: {id} does not exist!");
                return false;
            }

            await _bookingRepository.DeleteAsync(deleteBooking);
            return true;
        }

        public async Task<bool> EditBooking(BookingRequestModel booking)
        {
            if (booking == null) return false;

            var old = await _bookingRepository.GetByIdAsync(booking.Id);
            if (old == null)
            {
                Console.WriteLine($"ID : {booking.Id} does not exist!");
                return false;
            }

            old.Id = booking.Id;
            old.RoomNO = booking.RoomNO;
            old.CName = booking.CName;
            old.Address = booking.Address;
            old.Phone = booking.Phone;
            old.Email = booking.Email;
            old.CheckIn = booking.CheckIn;
            old.TotalPersons = booking.TotalPersons;
            old.BookingDays = booking.BookingDays;
            old.Advance = booking.Advance;

            var edited = await _bookingRepository.UpdateAsync(old);
            if (edited == null) return false;

            return true;
        }

        public async Task<BookingRequestModel> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking != null)
            {
                var model = new BookingRequestModel
                {
                    Id = booking.Id,
                    RoomNO = booking.RoomNO,
                    CName = booking.CName,
                    Address = booking.Address,
                    Phone = booking.Phone,
                    Email = booking.Email,
                    CheckIn = booking.CheckIn,
                    TotalPersons = booking.TotalPersons,
                    BookingDays = booking.BookingDays,
                    Advance = booking.Advance
                };
                return model;
            }
            else return null;
        }

        public async Task<IEnumerable<BookingRequestModel>> ListAllBookings()
        {
            var bookings = await _bookingRepository.ListAllAsync();
            if (bookings == null) return null;

            var models = new List<BookingRequestModel>();

            foreach(var booking in bookings)
            {
                var model = new BookingRequestModel
                {
                    Id = booking.Id,
                    RoomNO = booking.RoomNO,
                    CName = booking.CName,
                    Address = booking.Address,
                    Phone = booking.Phone,
                    Email = booking.Email,
                    CheckIn = booking.CheckIn,
                    TotalPersons = booking.TotalPersons,
                    BookingDays = booking.BookingDays,
                    Advance = booking.Advance
                };
                
                models.Add(model);
            }
            return models;
        }

     
    }
}
