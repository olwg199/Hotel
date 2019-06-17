using System.Collections.Generic;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.DomainEntities.Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public int BedsCount { get; set; }

        public int? RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}