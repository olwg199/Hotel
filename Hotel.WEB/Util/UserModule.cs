using AutoMapper;
using Hotel.BLL.Interfaces;
using Hotel.BLL.Services;
using Hotel.WEB.App_Start;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.WEB.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IMapper>().ToConstant(AutoMapperConfig.InitializeAutoMapper().CreateMapper());
        }
    }
}