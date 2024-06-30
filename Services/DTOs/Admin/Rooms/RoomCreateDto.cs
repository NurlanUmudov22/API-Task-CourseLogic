using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Rooms
{
    public class RoomCreateDto
    {
        public string Name { get; set; }

        public int SeatCount { get; set; }
    }
}
