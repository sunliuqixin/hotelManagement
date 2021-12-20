using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServicesInterfaces
{
    public interface IServiceService
    {
        Task AddService(Service service);

        //
        Task EdditService(Service service);

        Task DeleteService(int id);

        Task<IEnumerable<Service>> ListService();
    }
}
