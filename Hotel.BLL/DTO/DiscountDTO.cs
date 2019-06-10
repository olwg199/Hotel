using Hotel.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Hotel.BLL.DTO
{
    public class DiscountDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DiscountValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<RoomType> RoomTypes { get; set; }
    }
}
