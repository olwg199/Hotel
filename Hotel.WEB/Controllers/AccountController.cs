using System.Linq;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hotel.Web.Models.Account;
using Hotel.WEB.Models.Home;
using Hotel.WEB.Models.Reservation;

namespace Hotel.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public AccountController() { }

        public AccountController(IUserService userService, IReservationService reservationService, IMapper mapper)
        {
            _userService = userService;
            _reservationService = reservationService;
            _mapper = mapper;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Profile/Index
        [HttpGet]
        public ActionResult Index()
        {
            var user = this.HttpContext.User.Identity;
            ProfileVm profile = _mapper.Map<ProfileVm>(_userService.Get(user.GetUserId()));

            profile.Reservations = _reservationService.GetByUser(user.GetUserId()).Select(x => _mapper.Map<ReservationVm>(x));

            return View("Account", profile);
        }

        // GET: Profile/Login
        [HttpPost]
        public ActionResult Edit(ProfileVm model)
        {
            return View();
        }

        // GET: Profile/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Profile/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVm model, string returnUrl)
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

                return RedirectToLocal(returnUrl);
            }
        }

        // GET: Profile/Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // Post: Profile/Registration
        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserDto user = _mapper.Map<RegistrationVm, UserDto>(model);

            OperationDetails details = await _userService.Registration(user);

            if (details.Succedeed)
            {
                var claim = await _userService.Login(model.UserName, model.Password);

                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(details.Property, details.Message);

                return View(model);
            }
        }

        // GET: Profile/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}