using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.DAL.Entities;
using Hotel.DAL.Identity.Entities;
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
            CreateMap<UserDTO, ApplicationUser>();

            CreateMap<ConvenienceDTO, Convenience>();
            CreateMap<Convenience, ConvenienceDTO>();

            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();

            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(r => r.RoomType.Id))
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(r => r.RoomType.Name));
            CreateMap<RoomDTO, Room>();

            CreateMap<RoomType, RoomTypeDTO>();
            CreateMap<RoomTypeDTO, RoomType>();

            CreateMap<Status, StatusDTO>();
            CreateMap<StatusDTO, Status>();
        }
    }
}
