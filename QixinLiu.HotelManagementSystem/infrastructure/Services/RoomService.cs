using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryIntetfaces;
using ApplicationCore.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public class RoomService : IRoomService
    {

        /**********************************************************
         * exchange the entities date from repository into models
         *********************************************************/


        protected readonly IRoomRepository _roomRepository;
        //protected readonly IRoomTypeRepository _roomTypeRepository;

        

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public async Task<bool> AddRoom(RoomRequestModel room)
        {
            if(room != null && room.RTCode != null){
                Room newRoom = new Room { 
                   RTCode = room.RTCode,
                   Status = room.Status
                };
                await _roomRepository.AddAsync(newRoom);
                return true;
            }
            else
            {
                throw new Exception(" New Room Must Contain RTCode");
            }
        }

        public async Task<RoomResponseModel> GetRoomById(int id) 
        {
            var room = await _roomRepository.GetByIdAsync(id);
            var model = new RoomResponseModel
            {
                Id = room.Id,
                RTCode = room.RTCode,
                Status = room.Status
            };
            return model;
        }

        

        public async Task<bool> DeleteRoom(int id)
        {
            var deleteRoom = await _roomRepository.GetByIdAsync(id);
            if (deleteRoom == null) return false;

            await _roomRepository.DeleteAsync(deleteRoom);
            return true;
        }

        public async Task<bool> EditRoom(RoomRequestModel room)
        {
            if (room.RTCode != null)
            {
                Room editRoom = new Room
                {
                    Id = room.Id,
                    RTCode = room.RTCode,
                    Status = room.Status
                };

                var success = await _roomRepository.UpdateAsync(editRoom);
                return true;
            }
            
            return false;
        }


        public async Task<RoomResponseModel> GetRoomDetails(int id)
        {
            var room = await _roomRepository.GetRoomDetails(id);
            if (room == null)
            {
                throw new Exception($"No Room Found with {id}");
            }
            var roomDetails = new RoomResponseModel
            {
                Id = room.Id,
                Status = room.Status
            };

            roomDetails.RoomType = 
                new RoomTypeResponseModel
                {
                    Id = room.RoomType.Id,
                    RTDESC = room.RoomType.RTDESC,
                    Rent = room.RoomType.Rent
                };

            foreach (var service in room.Services)
            {
                roomDetails.Services.Add(
                    new ServiceResponseModel
                    {
                        Id = service.Id,
                        RoomNO = service.RoomNO,
                        SDESC = service.SDESC,
                        Amount = service.Amount
                    }
                 );
            }

            foreach (var booking in room.Bookings)
            {
                roomDetails.Bookings.Add(
                    new BookingResponseModel
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
                    }
                );
            }
            return roomDetails;
        }

        public async Task<IEnumerable<RoomResponseModel>> ListRooms()
        {
            var rooms = await _roomRepository.ListAllAsync();
            List<RoomResponseModel> list = new List<RoomResponseModel>();
            foreach (var r in rooms)
            {
                list.Add( new RoomResponseModel
                {
                    Id = r.Id,
                    RTCode = r.RTCode,
                    Status = r.Status
                });
            }
            return list;
        }
    }
}
