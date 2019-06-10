using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.BLL.Services
{
    public class ConvenienceService : IService<ConvenienceDto>
    {
        private readonly IRepository<Convenience> _repository;
        private readonly IMapper _mapper;

        public ConvenienceService(IRepository<Convenience> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ConvenienceDto Get(int id)
        {
            return _mapper.Map<Convenience, ConvenienceDto>(_repository.Get(id));
        }

        public IEnumerable<ConvenienceDto> GetAll()
        {
            return _repository.GetAll().Select(c => _mapper.Map<Convenience, ConvenienceDto>(c)).ToList();
        }

        public void Create(ConvenienceDto item)
        {
            Convenience conv = _mapper.Map<ConvenienceDto, Convenience>(item);

            _repository.Create(conv);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(ConvenienceDto item)
        {
            Convenience conv = _mapper.Map<ConvenienceDto, Convenience>(item);

            _repository.Update(conv);
        }
    }
}
