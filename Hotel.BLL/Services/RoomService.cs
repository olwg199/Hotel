using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Services
{
    public class RoomService : IService<RoomDto>
    {
        private IRepository<Room> _repository;
        private IMapper _mapper;

        public RoomService(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public RoomDto Get(int id)
        {
            return _mapper.Map<Room, RoomDto>(_repository.Get(id));
        }

        public IEnumerable<RoomDto> GetAll()
        {
            return _repository.GetAll().Select(r => _mapper.Map<Room, RoomDto>(r));
        }

        public void Create(RoomDto item)
        {
            Room room = _mapper.Map<RoomDto, Room>(item);

            _repository.Create(room);
        }

        public void Update(RoomDto item)
        {
            Room room = _mapper.Map<RoomDto, Room>(item);

            _repository.Update(room);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
