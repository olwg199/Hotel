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
    public class RoomTypeService : IService<RoomTypeDto>
    {
        private IRepository<RoomType> _repository;
        private IMapper _mapper;

        public RoomTypeService(IRepository<RoomType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public RoomTypeDto Get(int id)
        {
            return _mapper.Map<RoomType, RoomTypeDto>(_repository.Get(id));
        }

        public IEnumerable<RoomTypeDto> GetAll()
        {
            return _repository.GetAll()
                .Select(t => _mapper.Map<RoomType, RoomTypeDto>(t))
                .ToList();
        }

        public void Create(RoomTypeDto item)
        {
            RoomType type = _mapper.Map<RoomTypeDto, RoomType>(item);

            _repository.Create(type);
        }

        public void Update(RoomTypeDto item)
        {
            RoomType type = _mapper.Map<RoomTypeDto, RoomType>(item);

            _repository.Update(type);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
