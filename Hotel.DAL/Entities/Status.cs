using System.Collections.Generic;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.DomainEntities.Entities
{
    public class Status : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations{ get; set; }
    }
}