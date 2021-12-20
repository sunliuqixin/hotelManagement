using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{

    [Table("RoomType")]
    public class RoomType
    {
        public int Id { get; set; }

        public string ? RTDESC { get; set; }

        public decimal ? Rent { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
