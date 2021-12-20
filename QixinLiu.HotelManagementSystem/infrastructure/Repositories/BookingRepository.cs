using ApplicationCore.RepositoryIntetfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BookingRepository : EfRepository<Booking>, IBookingRepository
    {
       

        public BookingRepository(HMSDbContext hMSDbContext): base(hMSDbContext)
        {
        }


        //public async Task AddBooking(Booking booking)
        //{
        //    await _dbContext.Bookings.AddAsync(booking);
        //    Console.WriteLine("add a booking");
        //}

        //public async Task DeleteBooking(int id)
        //{
        //    var booking = await _dbContext.Bookings.FindAsync()
        //    //await _dbContext.Bookings.Remove(b => b.id == id);
        //}

        //public Task EdditBooking(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Booking>> ListBooking()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Booking>> IBookingRepository.ListBooking()
        //{
        //    throw new NotImplementedException();
        //}

    }
}