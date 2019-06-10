using System.Linq;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.WEB.Areas.Admin.Models;
using Hotel.WEB.Models.Account;
using Hotel.WEB.Models.Reservation;
using Hotel.WEB.Models.Shared;

namespace Hotel.WEB.Infrastructure
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<RegistrationVm, UserDto>();
            
            CreateMap<CreateReservationVm, ReservationDto>();

            CreateMap<RoomDto, RoomDetailsVm>();
            CreateMap<RoomDetailsVm, RoomDto>();

            CreateMap<RoomTypeDto, RoomTypeVm>();
            CreateMap<RoomTypeVm, RoomTypeDto>();

            CreateMap<RoomTypeDto, RoomTypeDetailsVm>()
                .ForMember(
                    dest => dest.SelectedConveniences, 
                    opt => opt.MapFrom(t => t.Conveniences.Select(x => x.Id).ToArray()));
            CreateMap<RoomTypeDetailsVm, RoomTypeDto>()
                .ForMember(
                    dest => dest.Conveniences,
                    opt => opt.MapFrom(t => t.SelectedConveniences.Select(conv => new ConvenienceDto{Id = conv})));
        }
    }
}