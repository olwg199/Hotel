using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DAL.EF;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;

namespace Hotel.DAL.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private HotelDbContext _context;

        public ReservationRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Reservation Get(int id)
        {
            return _context.Reservations.Find(id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public IEnumerable<Reservation> Find(Func<Reservation, bool> predicate)
        {
            return  _context.Reservations.Where(predicate);
        }

        public void Create(Reservation item)
        {
            item.RoomType = _context.RoomTypes.Find(item.RoomType.Id);
            _context.Reservations.Add(item);
            _context.SaveChanges();
        }

        public void Update(Reservation item)
        {
            item.RoomType = _context.RoomTypes.Find(item.RoomType.Id);
            _context.Set<Reservation>().AddOrUpdate(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Reservation reservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            if (reservation == null)
            {
                throw new ArgumentException("Reservation with current id not found");
            }

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
