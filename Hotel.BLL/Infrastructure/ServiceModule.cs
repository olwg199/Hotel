using Hotel.BLL.Interfaces;
using Hotel.DAL.EF;
using Hotel.DAL.Identity.Entities;
using Hotel.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using Hotel.DAL.Repositories;

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
            Bind<ApplicationUserManager>().ToSelf();
            Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            Bind<HotelDbContext>().ToSelf().WithConstructorArgument(_connectionString);

            Bind<IRepository<Convenience>>().To<ConvenienceRepository>();
        }
    }
}
