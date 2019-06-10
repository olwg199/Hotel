using Hotel.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public int BedsCount { get; set; }

        public int RoomTypeId { get; set; }

        public string RoomTypeName { get; set; }
    }
}
