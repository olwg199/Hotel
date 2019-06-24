using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.BLL.Infrastructure;
using Hotel.BLL.Services.Generic;

namespace Hotel.BLL.Services
{
    public class ReservationService : GenericCrudService<ReservationDto, Reservation>, IReservationService
    {

        public ReservationService(IRepository<Reservation> repository, 
            IMapper mapper) : base(repository, mapper) { }

        public override void Create(ReservationDto item)
        {
            base.Create(item);
        }

        public IEnumerable<ReservationDto> GetByUser(string userId)
        {
            var list = Repository.Find(x => x.ClientId == userId).ToList();
            return list.Select(x => Mapper.Map<ReservationDto>(x));
        }

        public IEnumerable<ReservationDto> GetByStatus(Status status, string userId = "")
        {
            throw new System.NotImplementedException();
        }
    }
}
