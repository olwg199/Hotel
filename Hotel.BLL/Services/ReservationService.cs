using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;

namespace Hotel.BLL.Services
{
    public class ReservationService : IService<ReservationDTO>
    {
        private IRepository<Reservation> _repository;
        private IMapper _mapper;

        public ReservationService(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ReservationDTO Get(int id)
        {
            return _mapper.Map<ReservationDTO>(_repository.Get(id));
        }

        public IEnumerable<ReservationDTO> GetAll()
        {
            return _repository.GetAll().Select(x => _mapper.Map<ReservationDTO>(x)).ToList();
        }

        public void Create(ReservationDTO item)
        {
            Reservation reservation = _mapper.Map<Reservation>(item);
            _repository.Create(reservation);
        }

        public void Update(ReservationDTO item)
        {
            _repository.Update(_mapper.Map<Reservation>(item));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
