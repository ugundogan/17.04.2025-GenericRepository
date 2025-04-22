using Microsoft.AspNetCore.Identity;

namespace ToDo_Cozuum.ViewModels
{
    public class Eylem_VM
    {
        public int EylemID { get; set; }
        public string EylemAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime EylemTarihi { get; set; }
        public string KategoriAdi { get; set; }
        public bool EylemYapildiMi { get; set; }

        public string UserID { get; set; }
    }
}
