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

            CreateMap<RoomDTO, RoomDetailsVM>();
            CreateMap<RoomDetailsVM, RoomDTO>();
        }
    }
}