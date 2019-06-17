using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.BLL.Interfaces;

namespace Hotel.BLL.DTO
{
    public class ReservationDto : IDto
    {
        public int Id { get; set; }

        public string ClientId { get; set; }

        public string ManagerId { get; set; }

        public RoomDto Room { get; set; }

        public RoomTypeDto RoomType { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public StatusDto Status { get; set; }
    }
}
