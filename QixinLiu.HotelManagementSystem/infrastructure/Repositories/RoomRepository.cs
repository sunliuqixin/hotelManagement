using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Models;
using ApplicationCore.RepositoryIntetfaces;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    /***********************************************************
     * get date from DB set using LINQ func
     ********************************************************/

    public class RoomRepository : 
        EfRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelMangageDb hMSDbContext)
            : base(hMSDbContext)
        {
            
        }

        public async Task<Room> GetRoomDetails(int id)
        {
            var room = await _dbContext.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.Services)
                .Include(r => r.Bookings)
                .FirstOrDefaultAsync(r => r.Id == id);
            return room;
        }
    }
}
