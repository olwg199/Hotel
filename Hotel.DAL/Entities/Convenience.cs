using System.Collections.Generic;

namespace Hotel.DomainEntities.Entities
{
    public class Convenience
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}
