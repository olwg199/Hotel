using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Controllers
{
    public class ReservarionController : Controller
    {
        // GET: Reservarion/Create/Id
        public ActionResult Create(int id)
        {
            return View();
        }
    }
}