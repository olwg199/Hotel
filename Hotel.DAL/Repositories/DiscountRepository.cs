using Hotel.DAL.EF;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories
{
    class DiscountRepository : IRepository<Discount>
    {
        private HotelDbContext _context;

        public DiscountRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Discount Get(int id)
        {
            return _context.Discounts.Find(id);
        }

        public IEnumerable<Discount> Find(Func<Discount, bool> predicate)
        {
            return _context.Discounts.Where(predicate).ToList();
        }

        public IEnumerable<Discount> GetAll()
        {
            return _context.Discounts.Include(d => d.RoomTypes).ToList();
        }
        public void Create(Discount item)
        {
            _context.Discounts.Add(item);
            _context.SaveChanges();
        }

        public void Update(Discount item)
        {
            var discount = _context.Discounts.Find(item.Id);
            
            if(discount == null)
            {
                throw new ArgumentException("Discount with current Id not found");
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var discount = _context.Discounts.Find(id);

            if (discount == null)
            {
                throw new ArgumentException("Discount with current Id not found");
            }

            _context.Discounts.Remove(discount);
            _context.SaveChanges();
        }
    }
}
