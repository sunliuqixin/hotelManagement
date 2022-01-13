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
                return false;

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
                return false;
            }

        }

        public async Task<bool> EditRoomType(RoomTypeRequestModel model)
        {
            if (model != null && model.RTDESC != null)
            {
                var editType = await _roomTypeRepository.GetByIdAsync(model.Id);
                if (editType == null) return false;

                editType.RTDESC = model.RTDESC;
                editType.Rent = model.Rent;
                
                await _roomTypeRepository.UpdateAsync(editType);
                return true;
            }
            else
            {
                return false; 
            }
        }

        public async Task<IEnumerable<RoomTypeResponseModel>> ListRoomTypes()
        {
            var types = await _roomTypeRepository.ListAllAsync();
            var list = new List<RoomTypeResponseModel>();
            foreach (RoomType t in types)
            {
                var newType = new RoomTypeResponseModel
                {
                    Id = t.Id,
                    RTDESC = t.RTDESC,
                    Rent = t.Rent
                };

                list.Add(newType);
            }
            return list;
        }

        public async Task<RoomTypeResponseModel> GetRoomTypeById(int id)
        {
            var roomT = await _roomTypeRepository.GetByIdAsync(id);
            if (roomT == null)
            {
                Console.WriteLine($"Invalided ID: {id}");
                return null;
            }
            var model = new RoomTypeResponseModel
            {
                Id = roomT.Id,
                RTDESC = roomT.RTDESC,
                Rent = roomT.Rent
            };

            return model;
        }
    }
}
