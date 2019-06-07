using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BLL.DTO;

namespace Hotel.WEB.Models.Reservation
{
    public class CreateReservationVM
    {
        public CreateReservationVM() { }

        public CreateReservationVM(RoomTypeDTO type)
        {
            RoomType = type;
        }

        public UserDTO Cleint { get; set; }

        public RoomTypeDTO RoomType { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; }
    }
}