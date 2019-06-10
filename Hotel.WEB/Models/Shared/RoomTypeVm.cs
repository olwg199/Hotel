using Hotel.BLL.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.WEB.Models.Shared
{
    public class RoomTypeVm
    {
        public int Id { get; set; }

        public string PathToImage { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public string Description { get; set; }

        public IEnumerable<ConvenienceDto> Conveniences { get; set; }
    }
}