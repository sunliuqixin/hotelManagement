using ApplicationCore.Entities;
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


        public async Task AddService(Service service)
        {
            await _serviceRepository.AddAsync(service);
        }

        public async Task DeleteService(int id)
        {
            var deleteService = await _serviceRepository.GetByIdAsync(id);
            await _serviceRepository.DeleteAsync(deleteService);
        }

        public async Task EdditService(Service service)
        {
            await _serviceRepository.UpdateAsync(service);
        }

        public async Task<IEnumerable<Service>> ListService()
        {
            var services = await _serviceRepository.ListAllAsync();
            return services;
        }
    }
}
