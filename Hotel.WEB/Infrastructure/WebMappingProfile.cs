﻿using System.Linq;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.Web.Areas.Admin.Models;
using Hotel.Web.Models.Account;
using Hotel.Web.Models.Reservation;
using Hotel.Web.Models.Shared;
using Hotel.WEB.Areas.Admin.Models;
using Hotel.WEB.Models.Home;

namespace Hotel.Web.Infrastructure
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<UserDto, ProfileVm>();
            CreateMap<ProfileVm, UserDto>();

            CreateMap<RegistrationVm, UserDto>();

            CreateMap<ConvenienceDto, ConvenienceDetailsVm>();
            CreateMap<ConvenienceDetailsVm, ConvenienceDto>();
            
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