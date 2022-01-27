using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class RoomResponseModel
    {
        public RoomResponseModel()
        {
            RoomType = new RoomTypeResponseModel();
            Services = new List<ServiceResponseModel>();
            Bookings = new List<BookingResponseModel>();
        }
        public int Id { get; set; }

        public int? RTCode { get; set; }

        public bool? Status { get; set; }

        public string RT { get; set; }

        public RoomTypeResponseModel RoomType { get; set; }

        public List<ServiceResponseModel> Services { get; set; }

        public List<BookingResponseModel> Bookings { get; set; }
    }
}
