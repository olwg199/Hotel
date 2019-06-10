using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.EF;
using Hotel.DomainEntities.Identity.Entities;
using Hotel.DomainEntities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using Hotel.DomainEntities.Repositories;
using Ninject;

namespace Hotel.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<HotelDbContext>().ToSelf().WithConstructorArgument(_connectionString);
            Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().WithConstructorArgument("context", Kernel.Get<HotelDbContext>());
            Bind<ApplicationUserManager>().ToSelf();

            Bind<IRepository<Convenience>>().To<ConvenienceRepository>();
            Bind<IRepository<Discount>>().To<DiscountRepository>();
            Bind<IRepository<Reservation>>().To<ReservationRepository>();
            Bind<IRepository<Room>>().To<RoomRepository>();
            Bind<IRepository<RoomType>>().To<RoomTypeRepository>();
            Bind<IRepository<Status>>().To<StatusRepository>();
        }
    }
}
