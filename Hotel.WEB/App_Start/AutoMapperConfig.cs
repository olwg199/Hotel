using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.WEB.Models.Account;
using Hotel.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.WEB.App_Start
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