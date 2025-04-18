namespace WebApplication2.Models
{
    public class Yapilacak
    {
        public int YapilacakID { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime PlanlananTarih { get; set; }
        public DateTime EklemeTarih { get; set; }
        public bool YapildiMi { get; set; }
        public int KategoriID { get; set; }
        public int UyeID { get; set; }
        public Kategori? Kategori { get; set; }
        public Uye? Uye { get; set; }
    }
}
