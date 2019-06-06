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
    public class ConvenienceService : IService<ConvenienceDTO>
    {
        private IRepository<Convenience> _repository;
        private IMapper _mapper;

        public ConvenienceService(IRepository<Convenience> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ConvenienceDTO Get(int id)
        {
            return _mapper.Map<Convenience, ConvenienceDTO>(_repository.Get(id));
        }

        public IEnumerable<ConvenienceDTO> GetAll()
        {
            return _repository.GetAll().Select(c => _mapper.Map<Convenience, ConvenienceDTO>(c)).ToList();
        }

        public void Create(ConvenienceDTO item)
        {
            Convenience conv = _mapper.Map<ConvenienceDTO, Convenience>(item);

            _repository.Create(conv);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(ConvenienceDTO item)
        {
            Convenience conv = _mapper.Map<ConvenienceDTO, Convenience>(item);

            _repository.Update(conv);
        }
    }
}
