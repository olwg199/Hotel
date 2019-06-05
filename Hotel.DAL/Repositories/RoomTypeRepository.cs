using Hotel.DAL.EF;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Hotel.DAL.Repositories
{
    public class RoomTypeRepository : IRepository<RoomType>
    {
        private HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public RoomType Get(int id)
        {
            return _context.RoomTypes.AsNoTracking().Include(t => t.Conveniences).FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _context.RoomTypes.ToList();
        }

        public IEnumerable<RoomType> Find(Func<RoomType, bool> predicate)
        {
            return _context.RoomTypes.Where(predicate).ToList();
        }

        public void Create(RoomType item)
        {
            var ids = item.Conveniences.Select(i => i.Id).ToList();
            item.Conveniences = _context.Conveniences
                .Where(t => ids.Contains(t.Id))
                .ToList();

            _context.RoomTypes.Add(item);
            _context.SaveChanges();
        }

        public void Update(RoomType item)
        {
            var ids = item.Conveniences.Select(i => i.Id).ToList();
            item.Conveniences = _context.Conveniences
                .Where(t => ids.Contains(t.Id))
                .ToList();

            _context.Set<RoomType>().AddOrUpdate(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RoomType type = _context.RoomTypes.Find(id);

            if (type == null)
            {
                throw new ArgumentException("Room type with current Id not found");
            }

            _context.RoomTypes.Remove(type);
            _context.SaveChanges();
        }

    }
}
