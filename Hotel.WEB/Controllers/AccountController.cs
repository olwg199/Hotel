using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.BLL.Interfaces;
using Hotel.WEB.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public AccountController() { }

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var claim = await _userService.Login(model.UserName, model.Password);

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

        // Post: Account/Registration
        [HttpPost]
        public async Task<ActionResult> Registration(Registration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserDTO user = _mapper.Map<Registration, UserDTO>(model);

            OperationDetails details = await _userService.Registration(user);

            if (details.Succedeed)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(details.Property, details.Message);

                return View(model);
            }
        }

        // GET: Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}