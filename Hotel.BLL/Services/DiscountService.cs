using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.DAL.Entities;
using Hotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.BLL.Services
{
    public class DiscountService : IService<DiscountDto>
    {
        private readonly IRepository<Discount> _repository;
        private readonly IMapper _mapper;

        public DiscountService(IRepository<Discount> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DiscountDto Get(int id)
        {
            return _mapper.Map<Discount, DiscountDto>(_repository.Get(id));
        }

        public IEnumerable<DiscountDto> GetAll()
        {
            return _repository.GetAll().Select(d => _mapper.Map<Discount, DiscountDto>(d)).ToList();
        }

        public void Create(DiscountDto item)
        {
            Discount discount = _mapper.Map<DiscountDto, Discount>(item);

            _repository.Create(discount);
        }

        public void Update(DiscountDto item)
        {
            Discount discount = _mapper.Map<DiscountDto, Discount>(item);

            _repository.Create(discount);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
