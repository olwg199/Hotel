using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.BLL.Services
{
    public class StatusService : IService<StatusDto>
    {
        private readonly IRepository<Status> _repository;
        private readonly IMapper _mapper;

        public StatusService(IRepository<Status> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public StatusDto Get(int id)
        {
            return _mapper.Map<Status, StatusDto>(_repository.Get(id));
        }

        public IEnumerable<StatusDto> GetAll()
        {
            return _repository.GetAll().Select(s => _mapper.Map<Status, StatusDto>(s)).ToList();
        }

        public void Create(StatusDto item)
        {
            var status = _mapper.Map<StatusDto, Status>(item);

            _repository.Create(status);
        }

        public void Update(StatusDto item)
        {
            var status = _mapper.Map<StatusDto, Status>(item);

            _repository.Update(status);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
