using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapRepository _kitapRepository;
        private readonly KategoriRepository _kategoriRepository;
        private readonly YayinEviRepository _yayinEviRepository;
        private readonly YazarRepository _yazarRepository;
        private readonly IMapper _mapper;

        public KitapController(KitapRepository kitapRepository, KategoriRepository kategoriRepository, YayinEviRepository yayinEviRepository, YazarRepository yazarRepository, IMapper mapper)
        {
            _kitapRepository = kitapRepository;
            _kategoriRepository = kategoriRepository;
            _yayinEviRepository = yayinEviRepository;
            _yazarRepository = yazarRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<KitapListe_VM> kitapListesi = _kitapRepository.Listele().Select(x => new KitapListe_VM
            {
                KitapId = x.KitapId,
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                YazarId = x.YazarId,
                KategoriId = x.KategoriId,
                YayinEviId = x.YayinEviId
            }).ToList();
            return View(kitapListesi);
        }

        public IActionResult KitapEkle()
        {
            KitapEkleForm_VM kitapForm = new KitapEkleForm_VM();
            kitapForm.Yazarlar = new SelectList(_yazarRepository.Listele(), "YazarId", "Ad");
            kitapForm.YayinEvleri = new SelectList(_yayinEviRepository.Listele(), "YayinEviId", "YayinEviAdi");
            kitapForm.Kategoriler = new SelectList(_kategoriRepository.Listele(), "KategoriId", "KategoriAdi");
            kitapForm.Kitap = new KitapEkle_VM();
            return View(kitapForm);
        }

        [HttpPost]
        public IActionResult KitapEkle(KitapEkle_VM kitap)
        {
            if (ModelState.IsValid)
            {

                //Kitap yeniKitap = new Kitap
                //{
                //    KitapAdi = kitap.KitapAdi,
                //    Ozet = kitap.Ozet,
                //    SayfaSayisi = kitap.SayfaSayisi,
                //    Fiyat = kitap.Fiyat,
                //    YazarId = kitap.YazarId,
                //    KategoriId = kitap.KategoriId,
                //    YayinEviId = kitap.YayinEviId
                //};
                _kitapRepository.Ekle(_mapper.Map<Kitap>(kitap));
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult KitapDetay(int id)
        {
           
            return View(_kitapRepository.KitapDetay(id));
        }
    }
}
