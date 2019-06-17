using Hotel.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using Hotel.BLL.Interfaces;

namespace Hotel.BLL.DTO
{
    public class DiscountDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DiscountValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<RoomType> RoomTypes { get; set; }
    }
}
