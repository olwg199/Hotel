using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Interfaces
{
    public interface IRoomTypeService
    {
        RoomTypeDTO Get(int id);

        IEnumerable<RoomTypeDTO> GetAll();

        void Create(RoomTypeDTO item);

        void Update(RoomTypeDTO item);

        void Delete(int id);
    }
}
