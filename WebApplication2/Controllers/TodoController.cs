using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly YapilacakService _yapilacakService;
        private readonly UserManager<Uye> _userManager;

        public TodoController(YapilacakService yapilacakService, UserManager<Uye> userManager)
        {
            _yapilacakService = yapilacakService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var uyeID = Convert.ToInt32(_userManager.GetUserId(User));
            
            return View(_yapilacakService.Listele(uyeID));
        }

        public IActionResult Ekle()
        {
            return View(_yapilacakService.EkleFormGetir());
        }
        [HttpPost]
        public IActionResult Ekle(YapilacakEkle_VM yapilacak)
        {
            var uyeID = Convert.ToInt32(_userManager.GetUserId(User));

            if (ModelState.IsValid)
            {
                _yapilacakService.Ekle(yapilacak, uyeID);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Yapildi(int id)
        {
            _yapilacakService.YapildiDurumDegistir(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detay(int id)
        {
            return View(_yapilacakService.Detay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int id)
        {
            _yapilacakService.Sil(id);
            return RedirectToAction("Index");
        }

        public IActionResult Düzenle(int id)
        {
            var uyeID = Convert.ToInt32(_userManager.GetUserId(User));

            YapilacakGuncelleForm_VM form = _yapilacakService.GuncelleFormGetir(id, uyeID);
            if (form.Yapilacak.UyeID != Convert.ToInt32(uyeID))
            {
                return RedirectToAction("YetkisizGiris", "Login");
            }
            return View(form);
        }
        [HttpPost]
        public IActionResult Düzenle(YapilacakGuncelle_VM yapilacak)
        {
            if (ModelState.IsValid)
            {
                _yapilacakService.Guncelle(yapilacak);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
