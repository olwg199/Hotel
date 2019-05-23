using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.WEB.Models.Account;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController() { }

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var claim = await _userService.Authenticate(model.UserName, model.Password);

            if (claim == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View(model);
            }
            else
            {
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Account/Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
    }
}