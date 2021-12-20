using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Room")]
    public class Room
    {
        public int Id { get; set; }

        public int? RTCode { get; set; }

        public bool? Status { get; set; }

        public RoomType RoomType { get; set; }

        public ICollection<Service> Services { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
