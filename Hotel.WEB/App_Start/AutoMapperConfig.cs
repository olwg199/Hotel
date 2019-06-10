using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Web.Infrastructure;

namespace Hotel.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMappingProfile());
                cfg.AddProfile(new BLLMappingProfile());
            });

            return config;
        }
    }
}