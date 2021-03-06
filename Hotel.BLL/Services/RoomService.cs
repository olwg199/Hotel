﻿using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.BLL.Services.Generic;

namespace Hotel.BLL.Services
{
    public class RoomCrudService : GenericCrudService<RoomDto, Room>
    {
        public RoomCrudService(IRepository<Room> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
