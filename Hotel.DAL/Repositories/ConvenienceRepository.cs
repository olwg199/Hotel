using Hotel.DAL.EF;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories
{
    public class ConvenienceRepository : IRepository<Convenience>
    {
        private HotelDbContext _context;

        public ConvenienceRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Convenience Get(int id)
        {
            return _context.Conveniences.Find(id);
        }

        public IEnumerable<Convenience> Find(Func<Convenience, bool> predicate)
        {
            return _context.Conveniences.Where(predicate).ToList();
        }

        public IEnumerable<Convenience> GetAll()
        {
            return _context.Conveniences.Include(c => c.RoomTypes).ToList();
        }

        public void Create(Convenience item)
        {
            _context.Conveniences.Add(item);
            _context.SaveChanges();
        }

        public void Update(Convenience item)
        {
            var convenience = _context.Conveniences.Find(item.Id);

            if(convenience == null)
            {
                throw new ArgumentException("Convenience with current Id not found");
            }

            _context.Set<Convenience>().AddOrUpdate(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var convenience = _context.Conveniences.Find(id);
            if (convenience != null)
            {
                _context.Conveniences.Remove(convenience);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Convenience with current Id not found");
            }
        }
    }
}
