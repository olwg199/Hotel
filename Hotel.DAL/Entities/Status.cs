using System.Collections.Generic;

namespace Hotel.DomainEntities.Entities
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations{ get; set; }
    }
}