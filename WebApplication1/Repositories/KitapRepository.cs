using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(SahafDbContext context) : base(context)
        {
        }

        public KitapDetay_VM KitapDetay(int id)
        {
            KitapDetay_VM kitap = _table.Where(x => x.KitapId == id).Include(x => x.Kategori).Include(x => x.YayinEvi).Include(x => x.Yazar).Select(x => new KitapDetay_VM
            {
                KitapAdi = x.KitapAdi,
                Ozet = x.Ozet,
                SayfaSayisi = x.SayfaSayisi,
                Fiyat = x.Fiyat,
                KategoriAd = x.Kategori.KategoriAdi,
                YayinEviAd = x.YayinEvi.YayinEviAdi,
                YazarAd = x.Yazar.Ad
            }).FirstOrDefault();
            return kitap;
        }
    }
}
