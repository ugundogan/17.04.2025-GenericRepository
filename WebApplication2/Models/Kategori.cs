namespace WebApplication2.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public ICollection<Yapilacak>? Yapilacaklar { get; set; }
    }
}
