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
    public class ServiceService : IServiceService
    {
        protected readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        public async Task<bool> AddService(ServiceRequestModel model)
        {
            if(model != null)
            {
                Service newService = new Service
                {

                    RoomNO = model.RoomNO,
                    SDESC = model.SDESC,
                    Amount = model.Amount,
                    ServiceDate = model.ServiceDate
                };
                await _serviceRepository.AddAsync(newService);
                return true;
            }

            return false;
            
        }

        public async Task<bool> DeleteService(int id)
        {
            var deleteService = await _serviceRepository.GetByIdAsync(id);
            if (deleteService == null) return false;

            await _serviceRepository.DeleteAsync(deleteService);
            return true;
        }

        public async Task<bool> EditService(ServiceRequestModel model)
        {
            if (model == null) return false;
            var oldService = await _serviceRepository.GetByIdAsync(model.Id);
            if (oldService == null) return false;

            oldService.RoomNO = model.RoomNO;
            oldService.SDESC = model.SDESC;
            oldService.Amount = model.Amount;
            oldService.ServiceDate = model.ServiceDate;
            
            await _serviceRepository.UpdateAsync(oldService);
            return true;
        }

        public async Task<ServiceResponseModel> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null) throw new Exception("No such Service ID !");

            var model = new ServiceResponseModel
            {
                Id = service.Id,
                RoomNO = service.RoomNO,
                SDESC = service.SDESC,
                Amount = service.Amount,
                ServiceDate = service.ServiceDate
            };

            return model;
        }

        public async Task<IEnumerable<ServiceResponseModel>> ListAllServices()
        {
            var services = await _serviceRepository.ListAllAsync();
            List<ServiceResponseModel> serviceList = new List<ServiceResponseModel>();
            foreach (var service in services)
            {
                //var model = new ServiceResponseModel
                //{
                //    Id = service.Id,
                //    RoomNO = service.RoomNO,
                //    SDESC = service.SDESC,
                //    Amount = service.Amount,
                //    ServiceDate = service.ServiceDate
                //};
                serviceList.Add(
                    new ServiceResponseModel
                    {
                        Id = service.Id,
                        RoomNO = service.RoomNO,
                        SDESC = service.SDESC,
                        Amount = service.Amount,
                        ServiceDate = service.ServiceDate
                    }
                );
            }
            return serviceList;
        }

     
    }
}
