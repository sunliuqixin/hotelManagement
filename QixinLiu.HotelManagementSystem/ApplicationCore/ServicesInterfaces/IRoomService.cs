using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServicesInterfaces
{
    public interface IRoomService
    {
        Task<bool> AddRoom(RoomRequestModel room);

        Task<bool> EditRoom(RoomRequestModel room);

        Task<bool> DeleteRoom(int id);


        Task<IEnumerable<RoomResponseModel>> ListRooms();

        Task<RoomResponseModel> GetRoomDetails(int id);

        Task<RoomResponseModel> GetRoomById(int id);
        Task<bool> BookRoom(int? roomNO);
    }
}
