using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class KitapEkle_VM
    {
        public string KitapAdi { get; set; } = null!;

        public string Ozet { get; set; } = null!;

        public int SayfaSayisi { get; set; }

        public decimal Fiyat { get; set; }

        public int YazarId { get; set; }

        public int KategoriId { get; set; }

        public int YayinEviId { get; set; }

    }
}
