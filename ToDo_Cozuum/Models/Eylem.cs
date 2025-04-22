using Microsoft.AspNetCore.Identity;

namespace ToDo_Cozuum.Models
{
    public class Eylem
    {
        public int EylemID { get; set; }
        public string EylemAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime EylemTarihi { get; set; }
        public bool EylemYapildiMi { get; set; }
        public int KategoriID { get; set; }

        public string UserID { get; set; }

        public IdentityUser? User{ get; set; }
        public Kategori? Kategori { get; set; }
    }
}
