using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.Web.Models.Reservation;
using Hotel.Web.Models.Shared;
using Microsoft.AspNet.Identity;

namespace Hotel.Web.Controllers
{
    public class ReservarionController : Controller
    {
        private IService<RoomTypeDto> _roomTypeService;
        private IService<ReservationDto> _reservationService;
        private IMapper _mapper;

        public ReservarionController(IService<RoomTypeDto> roomTypeService, IService<ReservationDto> reservationService, IMapper mapper)
        {
            _roomTypeService = roomTypeService;
            _reservationService = reservationService;
            _mapper = mapper;
        }

        // POST: Reservarion/Create
        [HttpGet]
        public ActionResult Create(int id, DateTime ArrivalDate, DateTime DepartureDate)
        {
            CreateReservationVm model = new CreateReservationVm();
            model.RoomType = _mapper.Map<RoomTypeVm>(_roomTypeService.Get(id));
            model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");
            return View(model);
        }

        // POST: Reservarion/Create
        [HttpPost]
        public ActionResult Create(CreateReservationVm model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");
                return View(model);
            }

            ReservationDto reservation = _mapper.Map<ReservationDto>(model);
            reservation.ClientId = this.HttpContext.User.Identity.GetUserId();
            _reservationService.Create(reservation);
            return RedirectToAction("Index", "Home");
        }

        // GET: Reservarion/List/
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ReservationDto> reservations = _reservationService.GetAll();
            return View();
        }

        // GET: Reservarion/GetPartialRoomType
        [HttpPost]
        public ActionResult GetPartialRoomType(int id)
        {
            var model = _mapper.Map<RoomTypeVm>(_roomTypeService.Get(id));
            return PartialView("_RoomType", model);
        }
    }
}