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
            RoomType = new RoomTypeRequestModel();
            Services = new List<ServiceRequestModel>();
            Bookings = new List<BookingRequestModel>();
        }

        public int Id { get; set; }

        //public int? RTCode { get; set; }

        public bool? Status { get; set; }

        public RoomTypeRequestModel RoomType { get; set; }

        public List<ServiceRequestModel> Services { get; set; }

        public List<BookingRequestModel> Bookings { get; set; }


    }
}
