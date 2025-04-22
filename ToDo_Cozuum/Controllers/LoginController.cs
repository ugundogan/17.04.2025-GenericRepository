using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo_Cozuum.Services.LoginService;
using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(ILoginService loginService, IMapper mapper, SignInManager<IdentityUser> signInManager)
        {
            _loginService = loginService;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login_VM login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser? user = _loginService.Login(login);
                if (user != null)
                {
                    _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Eylem");
                }
            }
            ModelState.AddModelError("HATA", "Kullanıcı adı veya şifre hatalı");
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register_VM register)
        {
            if (ModelState.IsValid)
            {
                _loginService.Register(register);
            }
            return View();
        }
    }
}
