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
        public HotelDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<HotelDbContext>(new HotelDbInitializer());
        }

        public DbSet<Convenience> Conveniences{ get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }

    }

    internal class HotelDbInitializer : CreateDatabaseIfNotExists<HotelDbContext>
    {
        protected override void Seed(HotelDbContext context)
        {
            Convenience conv1 = new Convenience { Name = "Большая кровать" };
            Convenience conv2 = new Convenience { Name = "Мини-бар" };
            Convenience conv3 = new Convenience { Name = "Джакузи" };
            Convenience conv4 = new Convenience { Name = "Домашний кинотеатр" };
            Convenience conv5 = new Convenience { Name = "Бассейн" };

            context.Conveniences.AddRange(new List<Convenience> { conv1, conv2, conv3, conv4, conv5 });
            context.SaveChanges();

            RoomType type = new RoomType
            {
                Name = "Премиум",
                Description = "Отличный номер",
                Price = 10000,
                Conveniences = new List<Convenience> { conv1, conv2, conv3 }
            };

            RoomType type1 = new RoomType
            {
                Name = "Cтандарт",
                Description = "Отличный номер",
                Price = 5000,
                Conveniences = new List<Convenience> { conv4, conv5, conv3 }
            };

            RoomType type2 = new RoomType
            {
                Name = "Люкс",
                Description = "Отличный номер",
                Price = 15000,
                Conveniences = new List<Convenience> { conv1, conv2, conv3, conv4 }
            };

            context.RoomTypes.AddRange(new List<RoomType> { type, type1, type2 });

            base.Seed(context);
        }
    }
}
