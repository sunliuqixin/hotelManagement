using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServicesInterfaces
{
    public interface IBookingService
    {
        Task<bool> AddBooking(BookingRequestModel booking);

        Task<bool> EditBooking(BookingRequestModel booking);

        Task<bool> DeleteBooking(int id);

        Task<BookingResponseModel> GetBookingById(int id);

        Task<IEnumerable<BookingResponseModel>> ListAllBookings();

    }
}
