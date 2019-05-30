using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Interfaces
{
    public interface IStatusService
    {
        StatusDTO Get(int id);

        IEnumerable<StatusDTO> GetAll();

        void Create(StatusDTO item);

        void Update(StatusDTO item);

        void Delete(int id);
    }
}
