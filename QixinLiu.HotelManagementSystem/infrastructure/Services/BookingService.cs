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
            if (booking == null) return false;

            var newBooking = new Booking
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

        public async Task<bool> EditBooking(BookingRequestModel model)
        {
            if (model == null) return false;

            var original = await _bookingRepository.GetByIdAsync(model.Id);
            if (original == null)
            {
                Console.WriteLine($"ID : {model.Id} does not exist!");
                return false;
            }

            original.Id = model.Id;
            original.RoomNO = model.RoomNO;
            original.CName = model.CName;
            original.Address = model.Address;
            original.Phone = model.Phone;
            original.Email = model.Email;
            original.CheckIn = model.CheckIn;
            original.TotalPersons = model.TotalPersons;
            original.BookingDays = model.BookingDays;
            original.Advance = model.Advance;

            var edited = await _bookingRepository.UpdateAsync(original);
            if (edited == null)
            {
                Console.WriteLine("Update Failed!");
                return false;
            }

            return true;
        }

        public async Task<BookingResponseModel> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking != null)
            {
                return (new BookingResponseModel
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
                    });
            }
            else return null;
        }

        public async Task<IEnumerable<BookingResponseModel>> ListAllBookings()
        {
            var bookings = await _bookingRepository.ListAllAsync();
            if (bookings == null) return null;

            var models = new List<BookingResponseModel>();

            foreach(var booking in bookings)
            {
                models.Add(new BookingResponseModel
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
                    });
            }
            return models;
        }

     
    }
}
