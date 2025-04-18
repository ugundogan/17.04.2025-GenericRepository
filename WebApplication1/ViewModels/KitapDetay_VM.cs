using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class KitapDetay_VM
    {

        public string KitapAdi { get; set; } = null!;

        public string Ozet { get; set; } = null!;

        public int SayfaSayisi { get; set; }

        public decimal Fiyat { get; set; }

        public string YazarAd { get; set; }

        public string KategoriAd { get; set; }

        public string YayinEviAd { get; set; }
    }
}
