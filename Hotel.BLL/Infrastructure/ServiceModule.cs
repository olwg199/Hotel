using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DAL.Interfaces;
using UserStore.DAL.Repositories;

namespace Hotel.BLL.Infrastructure
{
    class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
        }
    }
}
