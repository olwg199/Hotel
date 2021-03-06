﻿using System;
using System.Collections.Generic;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.DomainEntities.Entities
{
    public class Discount : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DiscountValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}