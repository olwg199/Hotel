using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Interfaces
{
    public interface IDiscountService
    {
        DiscountDTO Get(int id);

        IEnumerable<DiscountDTO> GetAll();

        void Create(DiscountDTO item);

        void Update(DiscountDTO item);

        void Delete(int id);
    }
}
