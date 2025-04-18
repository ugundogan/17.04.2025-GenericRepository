using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        private readonly IMapper _mapper;
        public KitapRepository(SahafDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public KitapDetay_VM KitapDetay(int id)
        {
            var kitap = Bul(id);

            _context.Entry(kitap).Navigation("Kategori").Load();
            _context.Entry(kitap).Navigation("Yazar").Load();
            _context.Entry(kitap).Navigation("YayinEvi").Load();


            //Mapperin özel kullanımını anlatmak için burada Mapper kullanıdk..
            //NŞA'da Repository içerisinde yazılmaaaaaaz.
            KitapDetay_VM kitapDetay = _mapper.Map<KitapDetay_VM>(kitap);

            
            return kitapDetay;
        }
    }
}
