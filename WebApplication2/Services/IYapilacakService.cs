using WebApplication2.ViewModels;

namespace WebApplication2.Services
{
    public interface IYapilacakService
    {
        List<YapilacakListe_VM> Listele(int id);
        YapilacakDetay_VM Detay(int id);
        void YapildiDurumDegistir(int id);
        YapilacakEkleForm_VM EkleFormGetir();
        void Ekle(YapilacakEkle_VM yapilacak, int uyeID);
        void Sil(int id);
        YapilacakGuncelleForm_VM GuncelleFormGetir(int id, int uyeID);
        void Guncelle(YapilacakGuncelle_VM yapilacak);
    }
}
