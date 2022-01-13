﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.RepositoryIntetfaces;
using infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : EfRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HotelMangageDb hMSDbContext) : base(hMSDbContext)
        {

        }

    }
}
