using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServicesInterfaces
{
    public interface IServiceService
    {
        Task<bool> AddService(ServiceRequestModel service);

        
        Task<bool> EditService(ServiceRequestModel service);

        Task<bool> DeleteService(int id);

        Task<ServiceResponseModel> GetServiceById(int id);

        Task<IEnumerable<ServiceResponseModel>> ListAllServices();
    }
}
