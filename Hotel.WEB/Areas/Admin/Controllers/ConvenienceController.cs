using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.WEB.Areas.Admin.Models;
using PagedList;

namespace Hotel.Web.Areas.Admin.Controllers
{
    public class ConvenienceController : Controller
    {
        private readonly IConvenienceService _service;
        private readonly IMapper _mapper;

        public ConvenienceController(IConvenienceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Admin/Convenience/List
        [HttpGet]
        public ActionResult List(int? page, string sortBy)
        {
            sortBy = string.IsNullOrEmpty(sortBy) ? "" : sortBy;
            ViewBag.SortParameter = sortBy;
            var model = _service.GetAll(sortBy).Select(x => _mapper.Map<ConvenienceDetailsVm>(x));
            return View("List", model.ToPagedList(page ?? 1, 3));
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

            _service.Create(_mapper.Map<ConvenienceDto>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Convenience/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _mapper.Map<ConvenienceDetailsVm>(_service.Get(id));
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

            _service.Update(_mapper.Map<ConvenienceDto>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Convenience/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("List");
        }
    }
}