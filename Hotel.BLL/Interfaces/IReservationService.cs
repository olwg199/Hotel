using System.Collections.Generic;
using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.DomainEntities.Entities;

namespace Hotel.BLL.Interfaces
{
    public interface IReservationService : ICrudService<ReservationDto>
    {
        IEnumerable<ReservationDto> GetByUser(string userId);
        
        IEnumerable<ReservationDto> GetByStatus(Status status, string userId = "");
    }
}