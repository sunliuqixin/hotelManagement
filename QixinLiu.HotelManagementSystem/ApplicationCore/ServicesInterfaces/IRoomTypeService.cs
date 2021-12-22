using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServicesInterfaces
{
    public interface IRoomTypeService
    {
        Task<bool> AddRoomType(RoomTypeRequestModel type);

     
        Task<bool> EditRoomType(RoomTypeRequestModel type);

        Task<bool> DeleteRoomType(int id);

        Task<IEnumerable<RoomTypeRequestModel>> ListRoomTypes();

        Task<RoomTypeRequestModel> GetRoomTypeById(int id);
    }
}
