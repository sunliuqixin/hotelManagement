using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class BookingResponseModel
    {
        public BookingResponseModel()
        {
            Room = new RoomResponseModel();
        }
        public int Id { get; set; }

        public int? RoomNO { get; set; }

        public string? CName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime? CheckIn { get; set; }

        public int? TotalPersons { get; set; }

        public int? BookingDays { get; set; }

        public decimal? Advance { get; set; }

        public RoomResponseModel Room { get; set; }
    }
}
