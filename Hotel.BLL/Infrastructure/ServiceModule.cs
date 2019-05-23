using Hotel.BLL.Interfaces;
using Hotel.DAL.EF;
using Ninject.Modules;

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
        }
    }
}
