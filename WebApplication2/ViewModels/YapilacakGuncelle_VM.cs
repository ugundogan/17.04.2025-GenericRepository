using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class YapilacakGuncelle_VM
    {
        public int YapilacakID { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public  int UyeID  { get; set; }
        public DateTime PlanlananTarih { get; set; }
        public DateTime EklemeTarih { get; set; }
        public int KategoriID { get; set; }
    }
}
