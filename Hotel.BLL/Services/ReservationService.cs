using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public ReservationService(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ReservationDto Get(int id)
        {
            return _mapper.Map<ReservationDto>(_repository.Get(id));
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            return _repository.GetAll().Select(x => _mapper.Map<ReservationDto>(x)).ToList();
        }

        public void Create(ReservationDto item)
        {
            Reservation reservation = _mapper.Map<Reservation>(item);
            _repository.Create(reservation);
        }

        public void Update(ReservationDto item)
        {
            _repository.Update(_mapper.Map<Reservation>(item));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
