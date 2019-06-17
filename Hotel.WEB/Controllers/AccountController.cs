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

namespace Hotel.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

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