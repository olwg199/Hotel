using Hotel.DAL.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public string CleintId { get; set; }

        public ApplicationUser Cleint { get; set; }

        public string ManagerId { get; set; }

        public ApplicationUser Manager { get; set; }

        public int? RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }

        public int? RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int? StatusId { get; set; }

        public Status Status { get; set; }
    }
}
