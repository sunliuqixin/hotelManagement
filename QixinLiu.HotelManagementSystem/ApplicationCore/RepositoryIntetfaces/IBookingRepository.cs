using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryIntetfaces
{
    public interface IBookingRepository: IAsyncRepository<Booking>
    {
        
    }
}
