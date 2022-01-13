using ApplicationCore.Entities;
using ApplicationCore.RepositoryIntetfaces;
using infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoomTypeRepository : 
        EfRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelMangageDb hMSDbContext) 
            : base(hMSDbContext)
        {

        }

    }
}
