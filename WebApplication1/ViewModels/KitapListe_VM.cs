using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class KitapListe_VM
    {
        public int KitapId { get; set; }

        public string KitapAdi { get; set; } = null!;

        public decimal Fiyat { get; set; }

        public int YazarId { get; set; }

        public int KategoriId { get; set; }

        public int YayinEviId { get; set; }

    }
}
