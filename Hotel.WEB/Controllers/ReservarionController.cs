using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.WEB.Models.Reservation;
using Microsoft.AspNet.Identity;

namespace Hotel.WEB.Controllers
{
    public class ReservarionController : Controller
    {
        private IService<RoomTypeDTO> _roomTypeService;
        private IService<ReservationDTO> _reservationService;
        private IMapper _mapper;

        public ReservarionController(IService<RoomTypeDTO> roomTypeService, IService<ReservationDTO> reservationService, IMapper mapper)
        {
            _roomTypeService = roomTypeService;
            _reservationService = reservationService;
            _mapper = mapper;
        }

        // GET: Reservarion/Create/Id
        [HttpGet]
        public ActionResult Create(int id)
        {
            CreateReservationVm model = new CreateReservationVm(_roomTypeService.Get(id));
            model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");
            return View(model);
        }

        // POST: Reservarion/Create/Id
        [HttpPost]
        public ActionResult Create(CreateReservationVm model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = new SelectList(_roomTypeService.GetAll(), "Id", "Name");
                return View(model);
            }

            ReservationDTO reservation = _mapper.Map<ReservationDTO>(model);
            reservation.ClientId = this.HttpContext.User.Identity.GetUserId();
            _reservationService.Create(reservation);
            return RedirectToAction("Index", "Home");
        }

        // GET: Reservarion/List/Id
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ReservationDTO> reservations = _reservationService.GetAll();
            return View();
        }
    }
}