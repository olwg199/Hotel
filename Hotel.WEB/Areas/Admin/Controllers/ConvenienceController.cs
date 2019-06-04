﻿using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Areas.Admin.Controllers
{
    public class ConvenienceController : Controller
    {
        private IConvenienceService _service;
        private IMapper _mapper;

        public ConvenienceController(IConvenienceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Admin/Convenience/List
        [HttpGet]
        public ActionResult List()
        {
            return View(_service.GetAll());
        }

        // GET: Admin/Convenience/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("EditOrCreate");
        }

        // POST: Admin/Convenience/Create
        [HttpPost]
        public ActionResult Create(ConvenienceDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditOrCreate", model);
            }

            _service.Create(model);

            return RedirectToAction("List");
        }

        // GET: Admin/Convenience/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View("EditOrCreate", _service.Get(id));
        }

        // POST: Admin/Convenience/Edit
        [HttpPost]
        public ActionResult Edit(ConvenienceDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditOrCreate", model);
            }

            _service.Update(model);

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