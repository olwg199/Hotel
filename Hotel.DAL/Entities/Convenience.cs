using System.Collections.Generic;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.DomainEntities.Entities
{
    public class Convenience : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}
