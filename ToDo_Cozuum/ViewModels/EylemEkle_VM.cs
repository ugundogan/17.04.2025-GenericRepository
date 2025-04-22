using Microsoft.AspNetCore.Identity;

namespace ToDo_Cozuum.ViewModels
{
    public class EylemEkle_VM
    {
        public string EylemAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime EylemTarihi { get; set; }
        public int KategoriID { get; set; }
        public string UserID { get; set; }

    }
}
