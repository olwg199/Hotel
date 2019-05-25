﻿using System.Collections.Generic;

namespace Hotel.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}