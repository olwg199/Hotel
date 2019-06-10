using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DomainEntities.Identity.Entities;

namespace Hotel.DomainEntities.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public string ClientId { get; set; }

        [Required]
        public ApplicationUser Client { get; set; }

        public string ManagerId { get; set; }

        public ApplicationUser Manager { get; set; }

        public int? RoomTypeId { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        public int? RoomId { get; set; }

        public Room Room { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        public int? StatusId { get; set; }

        public Status Status { get; set; }
    }
}
