using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.WEB.Areas.Admin.Models;

namespace Hotel.Web.Areas.Admin.Controllers
{
    public class ConvenienceController : Controller
    {
        private readonly ICrudService<ConvenienceDto> _crudService;
        private readonly IMapper _mapper;

        public ConvenienceController(ICrudService<ConvenienceDto> crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        // GET: Admin/Convenience/List
        [HttpGet]
        public ActionResult List()
        {
            var model = _crudService.GetAll().Select(x => _mapper.Map<ConvenienceDetailsVm>(x));
            return View("List", model);
        }

        // GET: Admin/Convenience/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Details");
        }

        // POST: Admin/Convenience/Create
        [HttpPost]
        public ActionResult Create(ConvenienceDetailsVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("Details", model);
            }

            _crudService.Create(_mapper.Map<ConvenienceDto>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Convenience/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _mapper.Map<ConvenienceDetailsVm>(_crudService.Get(id));
            return View("Details", model);
        }

        // POST: Admin/Convenience/Edit
        [HttpPost]
        public ActionResult Edit(ConvenienceDetailsVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("Details", model);
            }

            _crudService.Update(_mapper.Map<ConvenienceDto>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Convenience/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _crudService.Delete(id);
            return RedirectToAction("List");
        }

        // GET: Admin/Convenience/Delete/id
        [HttpGet]
        public ActionResult Search(string searchPattern)
        {
            ICollection<ConvenienceDto> model = new List<ConvenienceDto>();

            //_crudService.Search(searchPattern, out model);

            return RedirectToAction("List", model);
        }
    }
}