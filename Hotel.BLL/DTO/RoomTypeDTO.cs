using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.BLL.Interfaces;

namespace Hotel.BLL.DTO
{
    public class RoomTypeDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PathToImage { get; set; }

        public ICollection<ConvenienceDto> Conveniences { get; set; }
    }
}
