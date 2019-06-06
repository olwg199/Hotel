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
    public class StatusService : IService<StatusDTO>
    {
        private IRepository<Status> _repository;
        private IMapper _mapper;

        public StatusService(IRepository<Status> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public StatusDTO Get(int id)
        {
            return _mapper.Map<Status, StatusDTO>(_repository.Get(id));
        }

        public IEnumerable<StatusDTO> GetAll()
        {
            return _repository.GetAll().Select(s => _mapper.Map<Status, StatusDTO>(s)).ToList();
        }

        public void Create(StatusDTO item)
        {
            var status = _mapper.Map<StatusDTO, Status>(item);

            _repository.Create(status);
        }

        public void Update(StatusDTO item)
        {
            var status = _mapper.Map<StatusDTO, Status>(item);

            _repository.Update(status);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
