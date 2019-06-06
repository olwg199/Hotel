using AutoMapper;
using Hotel.BLL.Interfaces;
using Hotel.BLL.Services;
using Hotel.WEB.App_Start;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.BLL.DTO;

namespace Hotel.WEB.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IService<DiscountDTO>>().To<DiscountService>();
            Bind<IService<ConvenienceDTO>>().To<ConvenienceService>();
            Bind<IService<RoomDTO>>().To<RoomService>();
            Bind<IService<RoomTypeDTO>>().To<RoomTypeService>();
            Bind<IService<StatusDTO>>().To<StatusService>();
            Bind<IMapper>().ToConstant(AutoMapperConfig.InitializeAutoMapper().CreateMapper());
        }
    }
}