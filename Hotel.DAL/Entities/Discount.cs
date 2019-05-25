using System;
using System.Collections.Generic;

namespace Hotel.DAL.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public int DiscountValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}