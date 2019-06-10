using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.Interfaces;
using Hotel.WEB.Areas.Admin.Models;

namespace Hotel.WEB.Areas.Admin.Controllers
{
    public class RoomController : Controller
    {

        private readonly IService<RoomDTO> _roomService;
        private readonly IService<RoomTypeDTO> _roomTypeService;
        private readonly IMapper _mapper;

        public RoomController(IService<RoomDTO> roomService, IService<RoomTypeDTO> roomTypeService, IMapper mapper)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _mapper = mapper;
        }

        // GET: Admin/Room/List
        [HttpGet]
        public ActionResult List()
        {
            return View(_roomService.GetAll());
        }

        // GET: Admin/Room/Create
        [HttpGet]
        public ActionResult Create()
        {
            RoomDetails model = new RoomDetails();
            model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");

            return View("Details", model);
        }
        
        // POST: Admin/Room/Create
        [HttpPost]
        public ActionResult Create(RoomDetails model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");
                return View("Details", model);
            }

            _roomService.Create(_mapper.Map<RoomDetails, RoomDTO>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Room/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoomDetails model = _mapper.Map<RoomDetails>(_roomService.Get(id));
            model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");

            return View("Details", model);
        }

        // POST: Admin/Room/Edit
        [HttpPost]
        public ActionResult Edit(RoomDetails model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");
                return View("Details", model);
            }

            _roomService.Update(_mapper.Map<RoomDetails, RoomDTO>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/Room/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _roomService.Delete(id);

            return RedirectToAction("List");
        }
    }
}