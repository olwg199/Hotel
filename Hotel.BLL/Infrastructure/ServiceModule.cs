using Hotel.BLL.Interfaces;
using Hotel.DAL.EF;
using Hotel.DAL.Identity.Entities;
using Hotel.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;

namespace Hotel.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationUserManager>().ToSelf();
            Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            Bind<DbContext>().To<HotelDbContext>();
            Bind<HotelDbContext>().ToSelf();
        }
    }
}
