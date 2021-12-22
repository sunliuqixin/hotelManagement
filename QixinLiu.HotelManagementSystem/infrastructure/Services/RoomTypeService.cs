using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryIntetfaces;
using ApplicationCore.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RoomTypeService : IRoomTypeService
    {

        /**********************************************************
         * exchange the entities date from repository into models
         *********************************************************/

        protected readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }


        public async Task<bool> AddRoomType(RoomTypeRequestModel type)
        {
            if (type != null && type.RTDESC != null)
            {
                RoomType newType = new RoomType
                {
                    RTDESC = type.RTDESC,
                    Rent = type.Rent
                };
                await _roomTypeRepository.AddAsync(newType);
                return true;
            }
            else
            {
                throw new Exception
                    (" New Room Type Must Contain Vaild Room Type or RTDESC");

            }
        }

        public async Task<bool> DeleteRoomType(int id)
        {
            var deleteType = await _roomTypeRepository.GetByIdAsync(id);
            if (deleteType != null)
            {
                await _roomTypeRepository.DeleteAsync(deleteType);
                return true;
            }
            else
            {
                throw new Exception($"No Such Room Type ID: {id}.");
            }

        }

        public async Task<bool> EditRoomType(RoomTypeRequestModel type)
        {
            if (type != null && type.RTDESC != null)
            {
                var newType = new RoomType
                {
                    RTDESC = type.RTDESC,
                    Rent = type.Rent
                };
                await _roomTypeRepository.UpdateAsync(newType);
                return true;
            }
            else
            {
                throw new Exception("Room Type is Incorrect!");
            }
        }

        public async Task<IEnumerable<RoomTypeRequestModel>> ListRoomTypes()
        {
            var types = await _roomTypeRepository.ListAllAsync();
            var list = new List<RoomTypeRequestModel>();
            foreach (RoomType t in types)
            {
                var newType = new RoomTypeRequestModel
                {
                    Id = t.Id,
                    RTDESC = t.RTDESC,
                    Rent = t.Rent
                };

                list.Add(newType);
            }
            return list;
        }

        public async Task<RoomTypeRequestModel> GetRoomTypeById(int id)
        {
            var type = await _roomTypeRepository.GetByIdAsync(id);
            if (type == null)
            {
                Console.WriteLine($"Invalided ID: {id}");
                return null;
            }
            var editedType = new RoomTypeRequestModel
            {
                Id = type.Id,
                RTDESC = type.RTDESC,
                Rent = type.Rent
            };

            return editedType;
        }
    }
}
