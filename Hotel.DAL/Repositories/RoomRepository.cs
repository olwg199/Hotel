using Hotel.DAL.EF;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Hotel.DAL.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Room Get(int id)
        {
            return _context.Rooms.Find(id);
        }

        public IEnumerable<Room> Find(Func<Room, bool> predicate)
        {
            return _context.Rooms.Where(predicate).ToList();
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public void Create(Room item)
        {
            _context.Rooms.Add(item);
            _context.SaveChanges();
        }

        public void Update(Room item)
        {
            Room room = _context.Rooms.Find(item.Id);

            if(room == null)
            {
                throw new ArgumentException("Room with current Id not found");
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = _context.Rooms.Find(id);

            if (room == null)
            {
                throw new ArgumentException("Room with current Id not found");
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
