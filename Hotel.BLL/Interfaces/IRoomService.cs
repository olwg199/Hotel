﻿using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Interfaces
{
    public interface IRoomService
    {
        RoomDTO Get(int id);

        IEnumerable<RoomDTO> GetAll();

        void Create(RoomDTO item);

        void Update(RoomDTO item);

        void Delete(int id);
    }
}
