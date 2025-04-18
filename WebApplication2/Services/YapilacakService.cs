using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.ViewModels;

namespace WebApplication2.Services
{
    public class YapilacakService : IYapilacakService
    {
        private readonly YapilacakRepository _yapilacakRepository;
        private readonly KategoriRepository _kategoriRepository;
        private readonly IMapper _mapper;

        public YapilacakService(YapilacakRepository yapilacakRepository, KategoriRepository kategoriRepository, UserManager<Uye> userManager, IMapper mapper)
        {
            _yapilacakRepository = yapilacakRepository;
            _kategoriRepository = kategoriRepository;
            _mapper = mapper;
        }

        public YapilacakDetay_VM Detay(int id)
        {
            return (_yapilacakRepository.YapilacakDetay(id));
        }

        public void Ekle(YapilacakEkle_VM yapilacak, int uyeID)
        {
            Yapilacak yeniYapilacak = _mapper.Map<Yapilacak>(yapilacak);
            yeniYapilacak.EklemeTarih = DateTime.Now;
            yeniYapilacak.UyeID = uyeID;
            yeniYapilacak.YapildiMi = false;
            _yapilacakRepository.Ekle(yeniYapilacak);
        }

        public YapilacakEkleForm_VM EkleFormGetir()
        {
            YapilacakEkleForm_VM form = new();
            form.Kategoriler = new SelectList(_kategoriRepository.Listele(), "KategoriID", "KategoriAd");
            form.Yapilacak = new YapilacakEkle_VM();
            return form;
        }

        public void Guncelle(YapilacakGuncelle_VM yapilacak)
        {
            Yapilacak guncel = _mapper.Map<Yapilacak>(yapilacak);
            _yapilacakRepository.Guncelle(guncel);
        }

        public YapilacakGuncelleForm_VM GuncelleFormGetir(int id, int uyeID)
        {
            YapilacakGuncelleForm_VM form = new();
            form.Kategoriler = new SelectList(_kategoriRepository.Listele(), "KategoriID", "KategoriAd");
            form.Yapilacak = _mapper.Map<YapilacakGuncelle_VM>(_yapilacakRepository.Bul(id));
            return form;
        }

        public List<YapilacakListe_VM> Listele(int uyeID)
        {
            List<YapilacakListe_VM> liste = _mapper.Map<List<YapilacakListe_VM>>(_yapilacakRepository.ListeleQuery().Include(x => x.Kategori).Where(x => x.UyeID == uyeID));
            return liste;
        }

        public void Sil(int id)
        {
            _yapilacakRepository.Sil(id);
        }

        public void YapildiDurumDegistir(int id)
        {
            _yapilacakRepository.Yapildi(id);
        }
    }
}
