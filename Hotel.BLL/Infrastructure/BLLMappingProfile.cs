using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.DAL.Entities;
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
            CreateMap<UserDTO, ApplicationUser>()
                .ForMember("Id", opt => Guid.NewGuid().ToString());
        }
    }
}
