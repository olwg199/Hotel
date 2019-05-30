using Hotel.BLL.DTO;
using Hotel.DAL.Entities;
using System.Collections.Generic;

namespace Hotel.BLL.Interfaces
{
    public interface IConvenienceService
    {
        ConvenienceDTO Get(int id);

        IEnumerable<ConvenienceDTO> GetAll();

        void Create(ConvenienceDTO item);

        void Update(ConvenienceDTO item);

        void Delete(int id);
    }
}
