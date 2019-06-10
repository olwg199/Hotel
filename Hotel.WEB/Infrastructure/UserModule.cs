using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.BLL.Services;
using Hotel.WEB.App_Start;
using Ninject.Modules;

namespace Hotel.WEB.Infrastructure
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IService<DiscountDTO>>().To<DiscountService>();
            Bind<IService<ConvenienceDTO>>().To<ConvenienceService>();
            Bind<IService<ReservationDTO>>().To<ReservationService>();
            Bind<IService<RoomDTO>>().To<RoomService>();
            Bind<IService<RoomTypeDTO>>().To<RoomTypeService>();
            Bind<IService<StatusDTO>>().To<StatusService>();
            Bind<IMapper>().ToConstant(AutoMapperConfig.InitializeAutoMapper().CreateMapper());
        }
    }
}