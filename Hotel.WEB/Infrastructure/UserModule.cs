using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.BLL.Services;
using Hotel.Web.App_Start;
using Ninject.Modules;

namespace Hotel.Web.Infrastructure
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ICrudService<DiscountDto>>().To<DiscountCrudService>();
            Bind<ICrudService<ConvenienceDto>>().To<ConvenienceService>().InSingletonScope();
            Bind<IConvenienceService>().To<ConvenienceService>();
            Bind<IReservationService>().To<ReservationService>();
            Bind<ICrudService<ReservationDto>>().To<ReservationService>();
            Bind<ICrudService<RoomDto>>().To<RoomCrudService>();
            Bind<ICrudService<RoomTypeDto>>().To<RoomTypeCrudService>();
            Bind<ICrudService<StatusDto>>().To<StatusCrudService>();
            Bind<IMapper>().ToConstant(AutoMapperConfig.InitializeAutoMapper().CreateMapper());
        }
    }
}