using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DomainEntities.EF;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.DomainEntities.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        private HotelDbContext _context;

        public StatusRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Status Get(int id)
        {
            return _context.Statuses.Find(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Statuses.ToList();
        }

        public IEnumerable<Status> Find(Func<Status, bool> predicate)
        {
            return _context.Statuses.Where(predicate).ToList();
        }

        public void Create(Status item)
        {
            _context.Statuses.Add(item);
            _context.SaveChanges();
        }

        public void Update(Status item)
        {
            var status = _context.Statuses.Find(item.Id);

            if(status == null)
            {
                throw new ArgumentException("Status with current Id not found");
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var status = _context.Statuses.Find(id);

            if(status == null)
            {
                throw new ArgumentException("Status with current Id not found");
            }

            _context.Statuses.Remove(status);
            _context.SaveChanges();
        }
    }
}
