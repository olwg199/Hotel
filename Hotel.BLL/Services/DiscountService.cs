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
    class DiscountService : IDiscountService
    {
        private IRepository<Discount> _repository;
        private IMapper _mapper;

        public DiscountService(IRepository<Discount> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DiscountDTO Get(int id)
        {
            return _mapper.Map<Discount, DiscountDTO>(_repository.Get(id));
        }

        public IEnumerable<DiscountDTO> GetAll()
        {
            return _repository.GetAll().Select(d => _mapper.Map<Discount, DiscountDTO>(d)).ToList();
        }

        public void Create(DiscountDTO item)
        {
            Discount discount = _mapper.Map<DiscountDTO, Discount>(item);

            _repository.Create(discount);
        }

        public void Update(DiscountDTO item)
        {
            Discount discount = _mapper.Map<DiscountDTO, Discount>(item);

            _repository.Create(discount);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
