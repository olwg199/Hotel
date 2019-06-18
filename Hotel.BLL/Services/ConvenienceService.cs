using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Hotel.BLL.Services.Generic;

namespace Hotel.BLL.Services
{
    public class ConvenienceService : GenericCrudService<ConvenienceDto, Convenience>, IConvenienceService
    {
        public ConvenienceService(IRepository<Convenience> repository, IMapper mapper) : base(repository, mapper) { }

        public IEnumerable<ConvenienceDto> GetAll(string sortBy)
        {
            IEnumerable<Convenience> list;
            switch (sortBy)
            {
                case "Name":
                    list = Repository.GetAll().OrderBy(x => x.Name);
                    break;
                default:
                    list = Repository.GetAll();
                    break;
            }

            return list.Select(x => Mapper.Map<ConvenienceDto>(x));
        }
    }
}
