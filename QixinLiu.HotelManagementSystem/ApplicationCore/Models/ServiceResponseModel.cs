using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ServiceResponseModel
    {
        public ServiceResponseModel()
        {
            Room = new RoomResponseModel();
        }
        public int Id { get; set; }

        public int? RoomNO { get; set; }

        public string? SDESC { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? ServiceDate { get; set; }

        public RoomResponseModel Room { get; set; }

    }
}
