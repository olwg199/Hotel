using Hotel.DAL.Entities;
using Hotel.DAL.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.EF
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelDbContext() { }

        public HotelDbContext(string connectionString) : base(connectionString) { }

        public DbSet<Convenience> Conveniences{ get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }

    }
}
