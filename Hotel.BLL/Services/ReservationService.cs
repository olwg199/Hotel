using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.BLL.Services.Generic;

namespace Hotel.BLL.Services
{
    public class ReservationService : GenericCrudService<ReservationDto, Reservation>, IReservationService
    {
        public ReservationService(IRepository<Reservation> repository, IMapper mapper):base(repository, mapper) { }
        public IEnumerable<ReservationDto> GetByUser(string userId)
        {
            var list = Repository.Find(x => x.ClientId == userId);
            return list.Select(x => Mapper.Map<ReservationDto>(x));
        }
    }
}
