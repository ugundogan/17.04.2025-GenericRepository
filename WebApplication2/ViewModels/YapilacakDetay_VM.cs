using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class YapilacakDetay_VM
    {
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime PlanlananTarih { get; set; }
        public DateTime EklemeTarih { get; set; }
        public bool YapildiMi { get; set; }
        public string KategoriAd{ get; set; }
    }
}
