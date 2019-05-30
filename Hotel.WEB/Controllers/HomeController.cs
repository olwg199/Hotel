using Hotel.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IConvenienceService _service;

        public HomeController(IConvenienceService service)
        {
            _service = service;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}