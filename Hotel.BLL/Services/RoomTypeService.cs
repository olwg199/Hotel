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
    public class RoomTypeService : IService<RoomTypeDTO>
    {
        private IRepository<RoomType> _repository;
        private IMapper _mapper;

        public RoomTypeService(IRepository<RoomType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public RoomTypeDTO Get(int id)
        {
            return _mapper.Map<RoomType, RoomTypeDTO>(_repository.Get(id));
        }

        public IEnumerable<RoomTypeDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(t => _mapper.Map<RoomType, RoomTypeDTO>(t))
                .ToList();
        }

        public void Create(RoomTypeDTO item)
        {
            RoomType type = _mapper.Map<RoomTypeDTO, RoomType>(item);

            _repository.Create(type);
        }

        public void Update(RoomTypeDTO item)
        {
            RoomType type = _mapper.Map<RoomTypeDTO, RoomType>(item);

            _repository.Update(type);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
