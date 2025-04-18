using AutoMapper;
using Microsoft.Identity.Client;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Repositories
{
    public class YapilacakRepository : BaseRepository<Yapilacak>
    {
        private readonly IMapper _mapper;
        public YapilacakRepository(TodoDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public void Yapildi(int id)
        {
            var yapilacak = Bul(id);
            yapilacak.YapildiMi = !yapilacak.YapildiMi;
            _context.SaveChanges();
        }
        public YapilacakDetay_VM YapilacakDetay(int id)
        {
            var yapilacak = Bul(id);

            _context.Entry(yapilacak).Navigation("Kategori").Load();

            //Mapperin özel kullanımını anlatmak için burada Mapper kullanıdk..
            //NŞA'da Repository içerisinde yazılmaaaaaaz.
            YapilacakDetay_VM yapilacakDetay = _mapper.Map<YapilacakDetay_VM>(yapilacak);


            return yapilacakDetay;
        }
    }
}
