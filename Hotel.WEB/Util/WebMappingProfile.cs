using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.WEB.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.WEB.Areas.Admin.Models;

namespace Hotel.WEB.Util
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<Registration, UserDTO>();

            CreateMap<RoomDTO, RoomDetails>();
            CreateMap<RoomDetails, RoomDTO>();

            CreateMap<RoomTypeDTO, RoomTypeDetails>()
                .ForMember(
                    dest => dest.SelectedConveniences, 
                    opt => opt.MapFrom(t => t.Conveniences.Select(x => x.Id).ToArray()));
            CreateMap<RoomTypeDetails, RoomTypeDTO>()
                .ForMember(
                    dest => dest.Conveniences,
                    opt => opt.MapFrom(t => t.SelectedConveniences.Select(conv => new ConvenienceDTO{Id = conv})));
        }
    }
}