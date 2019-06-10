using System.Collections.Generic;

namespace Hotel.DAL.Entities
{
    public class RoomType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string PathToImage { get; set; }

        public virtual ICollection<Convenience> Conveniences { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
    }
}