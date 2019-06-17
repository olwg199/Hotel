using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.Interfaces;
using Hotel.Web.Areas.Admin.Models;

namespace Hotel.Web.Areas.Admin.Controllers
{
    public class RoomController : Controller
    {

        private readonly ICrudService<RoomDto> _roomCrudService;
        private readonly ICrudService<RoomTypeDto> _roomTypeCrudService;
        private readonly IMapper _mapper;

        public RoomController(ICrudService<RoomDto> roomCrudService, ICrudService<RoomTypeDto> roomTypeCrudService, IMapper mapper)
        {
            _roomCrudService = roomCrudService;
            _roomTypeCrudService = roomTypeCrudService;
            _mapper = mapper;
        }

        // GET: Admin/Room/List
        [HttpGet]
        public ActionResult List()
        {
            var model = _roomCrudService.GetAll().Select(x => _mapper.Map<RoomDetailsVm>(x));
            return View("List", model);
        }

        // GET: Admin/Room/Create
        [HttpGet]
        public ActionResult Create()
        {
            RoomDetailsVm model = new RoomDetailsVm();
            model.RoomTypes = new SelectList(_roomTypeCrudService.GetAll(), "Id", "Name");

            return View("Details", model);
        }
        
        // POST: Admin/Room/Create
        [HttpPost]
        public ActionResult Create(RoomDetailsVm model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = new SelectList(_roomTypeCrudService.GetAll(), "Id", "Name");
                return View("Details", model);
            }

            _roomCrudService.Create(_mapper.Map<RoomDetailsVm, RoomDto>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Room/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoomDetailsVm model = _mapper.Map<RoomDetailsVm>(_roomCrudService.Get(id));
            model.RoomTypes = new SelectList(_roomTypeCrudService.GetAll(), "Id", "Name");

            return View("Details", model);
        }

        // POST: Admin/Room/Edit
        [HttpPost]
        public ActionResult Edit(RoomDetailsVm model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = new SelectList(_roomTypeCrudService.GetAll(), "Id", "Name");
                return View("Details", model);
            }

            _roomCrudService.Update(_mapper.Map<RoomDetailsVm, RoomDto>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Room/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _roomCrudService.Delete(id);

            return RedirectToAction("List");
        }
    }
}