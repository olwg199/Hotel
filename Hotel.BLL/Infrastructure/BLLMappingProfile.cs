using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Infrastructure
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<ConvenienceDto, Convenience>();
            CreateMap<Convenience, ConvenienceDto>();

            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();

            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(r => r.RoomType.Id))
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(r => r.RoomType.Name));
            CreateMap<RoomDto, Room>();

            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<RoomTypeDto, RoomType>();

            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();
        }
    }
}
