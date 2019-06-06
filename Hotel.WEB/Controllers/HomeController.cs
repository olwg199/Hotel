﻿using Hotel.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace Hotel.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IRoomTypeService _service;
        private IMapper _mapper;

        public HomeController(IRoomTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }
    }
}