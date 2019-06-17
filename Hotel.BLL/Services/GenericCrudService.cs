using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.BLL.Services.Generic
{
    public class GenericCrudService<TDto, T> : ICrudService<TDto> 
        where TDto : IDto
        where T : class, IEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;

        public GenericCrudService() { }

        public GenericCrudService(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual TDto Get(int id)
        {
            T item = _repository.Get(id);
            return _mapper.Map<TDto>(item);
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var list = _repository.GetAll();
            return list.Select(x => _mapper.Map<TDto>(x));
        }

        public virtual void Create(TDto item)
        {
            _repository.Create(_mapper.Map<T>(item));
        }

        public virtual void Update(TDto item)
        {
            _repository.Update(_mapper.Map<T>(item));
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}