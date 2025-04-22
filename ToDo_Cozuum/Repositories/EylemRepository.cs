using ToDo_Cozuum.Data;
using ToDo_Cozuum.Models;
using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Repositories
{
    public class EylemRepository : BaseRepository<Eylem>
    {
        public EylemRepository(ToDooDbContext context) : base(context)
        {
        }
        public List<Eylem_VM> Listele(string id)
        {
            return _table.Select(x => new Eylem_VM {
                EylemID = x.EylemID,
                EylemAdi = x.EylemAdi,
                Aciklama = x.Aciklama,
                EylemTarihi = x.EylemTarihi,
                KategoriAdi = x.Kategori.KategoriAdi,
                OlusturmaTarihi = x.OlusturmaTarihi,
                UserID = x.UserID,
                EylemYapildiMi = x.EylemYapildiMi
            }).Where(x => x.UserID == id).ToList();
        }
    }
}
