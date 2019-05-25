using AutoMapper;
using Hotel.BLL.DTO;
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
        }
    }
}
