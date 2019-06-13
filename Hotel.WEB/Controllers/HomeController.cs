﻿using Hotel.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.Web.Models.Shared;
using Hotel.WEB.Models.Home;
using Hotel.WEB.Models.Reservation;
using Microsoft.AspNet.Identity;

namespace Hotel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<ReservationDto> _reservationService;
        private readonly IService<RoomTypeDto> _roomTypeService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HomeController(IService<RoomTypeDto> roomTypeService, IUserService userService, IService<ReservationDto> reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _roomTypeService = roomTypeService;
            _userService = userService;
            _mapper = mapper;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_roomTypeService.GetAll().Select(x => _mapper.Map<RoomTypeVm>(x)));
        }

        // GET: Home
        [HttpGet]
        [Authorize(Roles = "User, Manager")]
        public ActionResult Profile()
        {
            ProfileVm profile = _mapper.Map<ProfileVm>(_userService.Get(this.HttpContext.User.Identity.GetUserId()));
            if (this.HttpContext.User.IsInRole("User"))
            {
                return View("Profile", profile);
            }

            if (this.HttpContext.User.IsInRole("Manager"))
            {
                profile.Reservations = _reservationService.GetAll().Select(x => _mapper.Map<ReservationVm>(x));
                return View("Profile", profile);
            }

            return HttpNotFound();
        }
    }
}