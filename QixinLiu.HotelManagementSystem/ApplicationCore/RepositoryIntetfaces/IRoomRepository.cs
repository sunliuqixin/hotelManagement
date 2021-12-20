using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryIntetfaces
{
    public interface IRoomRepository : IAsyncRepository<Room>
    {
        Task<Room> GetRoomDetails(int id);
        //Task AddAsync(Room room);
    }
}
