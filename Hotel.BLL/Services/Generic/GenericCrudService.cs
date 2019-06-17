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
        protected readonly IRepository<T> Repository;
        protected readonly IMapper Mapper;

        public GenericCrudService() { }

        public GenericCrudService(IRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual TDto Get(int id)
        {
            T item = Repository.Get(id);
            return Mapper.Map<TDto>(item);
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var list = Repository.GetAll();
            return list.Select(x => Mapper.Map<TDto>(x));
        }

        public virtual void Create(TDto item)
        {
            Repository.Create(Mapper.Map<T>(item));
        }

        public virtual void Update(TDto item)
        {
            Repository.Update(Mapper.Map<T>(item));
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);
        }
    }
}