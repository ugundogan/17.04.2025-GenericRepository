using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.MapperClasses
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kitap, KitapEkle_VM>().ReverseMap();
            CreateMap<Kitap, KitapDetay_VM>()
                .ForMember(x => x.KategoriAd, y => y.MapFrom(z => z.Kategori.KategoriAdi))
                .ForMember(x => x.YazarAd, y => y.MapFrom(z => z.Yazar.YazarAdSoyad))
                .ForMember(x => x.YayinEviAd, y => y.MapFrom(z => z.YayinEvi.YayinEviAdi))
                .ReverseMap();
            CreateMap<Kitap, KitapListe_VM>().ReverseMap();
        }
    }
}
