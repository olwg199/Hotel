using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Identity;
using Hotel.DomainEntities.Identity.Entities;
using Microsoft.AspNet.Identity;

namespace Hotel.DomainEntities.EF
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

    }

    internal class HotelDbInitializer : CreateDatabaseIfNotExists<HotelDbContext>
    {
        protected override void Seed(HotelDbContext context)
        {
            ApplicationRole role = new ApplicationRole { Name = "Admin" };
            ApplicationRole role1 = new ApplicationRole { Name = "Manager" };
            ApplicationRole role2 = new ApplicationRole { Name = "User" };

            context.Roles.Add(role);
            context.Roles.Add(role1);
            context.Roles.Add(role2);
            context.SaveChanges();

            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationUser user = new ApplicationUser { Email = "a@g.m", UserName = "Admin"};
            ApplicationUser user1 = new ApplicationUser { Email = "m@g.m", UserName = "Manager" };
            ApplicationUser user2 = new ApplicationUser { Email = "u@g.m", UserName = "User"};
            manager.Create(user, "1234qweR!");
            manager.AddToRole(user.Id, role.Name);
            manager.Create(user1, "!234qweR");
            manager.AddToRole(user1.Id, role1.Name);
            manager.Create(user2, "!234qweR");
            manager.AddToRole(user2.Id, role2.Name);


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
                Price = 200M,
                PathToImage = "/Content/img/1.jpg",
                Conveniences = new List<Convenience> { conv1, conv2, conv3 }
            };

            RoomType type1 = new RoomType
            {
                Name = "Cтандарт",
                Description = "Отличный номер",
                Price = 100M,
                PathToImage = "/Content/img/2.jpg",
                Conveniences = new List<Convenience> { conv4, conv5, conv3 }
            };

            RoomType type2 = new RoomType
            {
                Name = "Люкс",
                Description = "Отличный номер",
                Price = 150M,
                PathToImage = "/Content/img/3.jpg",
                Conveniences = new List<Convenience> { conv1, conv2, conv3, conv4 }
            };

            context.RoomTypes.AddRange(new List<RoomType> { type, type1, type2 });
            context.SaveChanges();

            Room room = new Room { RoomNumber = 13, BedsCount = 1, RoomType = type };
            Room room1 = new Room { RoomNumber = 14, BedsCount = 2, RoomType = type };
            Room room2 = new Room { RoomNumber = 15, BedsCount = 2, RoomType = type };
            Room room3 = new Room { RoomNumber = 16, BedsCount = 3, RoomType = type };
            Room room4 = new Room { RoomNumber = 23, BedsCount = 2, RoomType = type1 };
            Room room5 = new Room { RoomNumber = 24, BedsCount = 4, RoomType = type1 };
            Room room6 = new Room { RoomNumber = 27, BedsCount = 2, RoomType = type2 };
            Room room7 = new Room { RoomNumber = 28, BedsCount = 2, RoomType = type2 };

            context.Rooms.AddRange(new List<Room> { room, room1, room2, room3, room4, room5, room6, room7 });

            base.Seed(context);
        }
    }
}
