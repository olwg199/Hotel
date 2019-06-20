using System.Collections.Generic;
using Hotel.BLL.DTO;

namespace Hotel.BLL.Interfaces
{
    public interface IReservationService : ICrudService<ReservationDto>
    {
        IEnumerable<ReservationDto> GetByUser(string userId);
    }
}