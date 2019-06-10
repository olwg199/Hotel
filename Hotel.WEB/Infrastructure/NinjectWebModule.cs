using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.BLL.Services;
using Hotel.WEB.App_Start;
using Ninject.Modules;

namespace Hotel.WEB.Infrastructure
{
    public class NinjectWebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IService<DiscountDto>>().To<DiscountService>();
            Bind<IService<ConvenienceDto>>().To<ConvenienceService>();
            Bind<IService<ReservationDto>>().To<ReservationService>();
            Bind<IService<RoomDto>>().To<RoomService>();
            Bind<IService<RoomTypeDto>>().To<RoomTypeService>();
            Bind<IService<StatusDto>>().To<StatusService>();
            Bind<IMapper>().ToConstant(AutoMapperConfig.InitializeAutoMapper().CreateMapper());
        }
    }
}