using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.BLL.Interfaces;

namespace Hotel.BLL.DTO
{
    public class ConvenienceDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
