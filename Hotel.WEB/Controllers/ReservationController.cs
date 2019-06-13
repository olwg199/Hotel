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
using Hotel.WEB.Models.Reservation;
using Microsoft.AspNet.Identity;

namespace Hotel.Web.Controllers
{
    [Authorize(Roles = "User, Manager")]
    public class ReservationController : Controller
    {
        private IService<RoomTypeDto> _roomTypeService;
        private IService<ReservationDto> _reservationService;
        private IMapper _mapper;

        public ReservationController(IService<RoomTypeDto> roomTypeService, IService<ReservationDto> reservationService, IMapper mapper)
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
            model.TotalPrice = (DepartureDate - ArrivalDate).Days * model.RoomType.Price;
            return View(model);
        }

        // POST: Reservarion/Create
        [HttpPost]
        public ActionResult Create(CreateReservationVm model)
        {
            if (!ModelState.IsValid && model.TotalPrice != 0M)
            {
                model.RoomType = _mapper.Map<RoomTypeVm>(_roomTypeService.Get(model.RoomType.Id));
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
            IEnumerable<ReservationVm> model = _reservationService.GetAll().Select(x => _mapper.Map<ReservationVm>(x));
            return PartialView("_ReservationList", model);
        }
    }
}