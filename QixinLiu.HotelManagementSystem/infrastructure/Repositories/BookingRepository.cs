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
       

        public BookingRepository(HotelMangageDb hMSDbContext): base(hMSDbContext)
        {
        }


    }
}