using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{

    [Table("Service")]
    public class Service
    {
        public int Id { get; set; }

        public int? RoomNO { get; set; }

        public string? SDESC { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? ServiceDate { get; set; }

        public Room Room { get; set; }
    }
}
