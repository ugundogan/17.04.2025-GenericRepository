using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Services
{
    
    public class LoginService : ILoginService
    {
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;

        public LoginService(UserManager<Uye> userManager, SignInManager<Uye> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Login(Login_VM login)
        {
            var result = _userManager.FindByNameAsync(login.UserName).Result;
            if (result != null)
            {
                bool sifreDogruMu = _userManager.CheckPasswordAsync(result, login.Password).Result;
                if (sifreDogruMu)
                {
                    await _signInManager.SignInAsync(result, false);
                    return true;
                }
            }
            return false;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Register(Register_VM register)
        {
            Uye yeniUye = new Uye
            {
                Ad = register.Ad,
                Soyad = register.Soyad,
                Email = register.EPosta,
                UserName = register.KullaniciAdi
            };

            var result = await _userManager.CreateAsync(yeniUye, register.Sifre);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
