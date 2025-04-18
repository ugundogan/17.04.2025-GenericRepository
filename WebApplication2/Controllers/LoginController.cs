using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;
        private readonly LoginService _loginService;
        public LoginController(UserManager<Uye> userManager, SignInManager<Uye> signInManager, LoginService loginService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login_VM login)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.FindByNameAsync(login.UserName).Result;
                if (result != null)
                {
                    bool sifreDogruMu = _userManager.CheckPasswordAsync(result, login.Password).Result;
                    if (sifreDogruMu)
                    {
                        await _signInManager.SignInAsync(result, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("HATA", "Kullanıcı adı veya şifre yanlış");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register_VM register)
        {
            if (ModelState.IsValid)
            {
                if (_loginService.Register(register).Result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    ModelState.AddModelError("HATA", strAck);
                }
            }
            return View();
        }

       
        public async Task<IActionResult> Logout()
        {
            _loginService.LogOut();
            return RedirectToAction("Index");
        }


    }
}
