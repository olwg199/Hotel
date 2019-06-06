using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.WEB.Areas.Admin.Models;

namespace Hotel.WEB.Areas.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        private IService<RoomTypeDTO> _roomTypeService;
        private IService<ConvenienceDTO> _convenienceService;
        private IMapper _mapper;

        public RoomTypeController(IService<RoomTypeDTO> roomTypeService, IService<ConvenienceDTO> convenienceService, IMapper mapper)
        {
            _roomTypeService = roomTypeService;
            _convenienceService = convenienceService;
            _mapper = mapper;
        }

        // GET: Admin/RoomType/List
        [HttpGet]
        public ActionResult List()
        {
            return View(_roomTypeService.GetAll());
        }

        // GET: Admin/RoomType/Create
        [HttpGet]
        public ActionResult Create()
        {
            RoomTypeDetails model = new RoomTypeDetails();
            model.AvailableConveniences = new SelectList(_convenienceService.GetAll(), "Id", "Name");

            return View("Details", model);
        }

        // POST: Admin/RoomType/Create
        [HttpPost]
        public ActionResult Create(RoomTypeDetails model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableConveniences = new SelectList(_convenienceService.GetAll(), "Id", "Name");
                return View(model);
            }

            _roomTypeService.Create(_mapper.Map<RoomTypeDTO>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/RoomType/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoomTypeDTO type = _roomTypeService.Get(id);
            RoomTypeDetails model = _mapper.Map<RoomTypeDetails>(type);
            model.AvailableConveniences = new MultiSelectList(_convenienceService.GetAll(), "Id", "Name", type.Conveniences);

            return View("Details", model);
        }

        // POST: Admin/RoomType/Edit
        [HttpPost]
        public ActionResult Edit(RoomTypeDetails model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableConveniences = new SelectList(_convenienceService.GetAll(), "Id", "Name");
                return View(model);
            }

            _roomTypeService.Update(_mapper.Map<RoomTypeDTO>(model));

            return RedirectToAction("List");
        }

        // GET: Admin/RoomType/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _roomTypeService.Delete(id);
            return RedirectToAction("List");
        }
    }
}